namespace Modul14;

public partial class Form1 : Form
{
    public Form1()
    {
        PreInitialize();
        InitializeComponent();
        PostInitialize();
    }

    partial void PostInitialize();

    partial void PreInitialize();

    private async void button1_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < 50; i++)
            {
                await Task.Delay(100);
                textBox1.Text = textBox1.Text + ".";
            }

            var text = await File.ReadAllTextAsync("Modul14.deps.json");
            textBox1.Text = text.Substring(0, 100);
        }
        catch (Exception ex)
        {
            textBox1.Text = ex.Message;
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    partial void PreInitialize()
    {
        Console.WriteLine("PreInitialize called");
    }
}
