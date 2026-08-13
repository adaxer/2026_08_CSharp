param(
    [Parameter(Mandatory = $true)]
    [string]$Path
)

$utf8Strict = [System.Text.UTF8Encoding]::new($false, $true)
$utf8NoBom  = [System.Text.UTF8Encoding]::new($false)
$win1252    = [System.Text.Encoding]::GetEncoding(1252)

$converted = @()

Get-ChildItem -Path $Path -Filter *.cs -File -Recurse | ForEach-Object {

    $file = $_
    $bytes = [System.IO.File]::ReadAllBytes($file.FullName)

    $isUtf8 = $true

    try {
        $null = $utf8Strict.GetString($bytes)
    }
    catch {
        $isUtf8 = $false
    }

    if (-not $isUtf8) {
        $text = $win1252.GetString($bytes)

        [System.IO.File]::WriteAllText(
            $file.FullName,
            $text,
            $utf8NoBom
        )

        $converted += $file.FullName

        Write-Host "Converted: $($file.FullName)"
    }
}

Write-Host ""
Write-Host "Finished."

if ($converted.Count -eq 0) {
    Write-Host "No files needed conversion."
}
else {
    Write-Host "$($converted.Count) file(s) converted from Windows-1252 to UTF-8:"
    $converted | ForEach-Object {
        Write-Host "  $_"
    }
}