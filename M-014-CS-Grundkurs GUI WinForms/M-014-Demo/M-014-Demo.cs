using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    //Bsp-Enum
    enum Test { Test1, Test2 }

    //PARTIAL besagt, dass diese Klasse in mehrere Teile (Dateien) aufgeteilt ist
    public partial class MainWindow : Form
    {
        //Konstruktor für das Form (Fenster)
        public MainWindow()
        {
            //Diese Methode initialisiert alle im Designer definierten Objekte. Sie sollte die erste Methode im Konstruktor sein
            InitializeComponent();

            //Neuzuweisung einer Property eines Buttons
            Btn_Ok.Text = "Ok";
            //Zuweisung eines weiteren EventHandlers zu einem Event
            Btn_Ok.Click += Btn_Ok_Click_02;

            for (int i = 0; i < Enum.GetValues(typeof(Test)).Length; i++)
            {
                //Befüllung der ComboBox mit Enum-Elementen
                Cbb_Auswahl.Items.Add((Test)i);
            }
        }

        //EventHandler-Methoden

        //EventHandler, welche auf einen Klick auf den Button 'OK# reagiert
        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            //Neuzuweisung einer Eigenschaft des Forms
            this.BackColor = Color.DarkOrange;
            //Neuzuweisung einer Eigenschaft des Labels
            this.Lbl_Anweisung.Text = "HALLO";

            //Prüfung, ob in der ComboBox ein Element angewählt wurde
            if (Cbb_Auswahl.SelectedItem != null)
                //Übertrag des Elements in das Label
                Lbl_Anweisung.Text = Cbb_Auswahl.SelectedItem.ToString();

            //Prüfung, ob die Checkbox abgehakt wurde
            if (Cbx_Haken.Checked)
                Lbl_Anweisung.Text = "Ist Richtig";
        }

        private void Btn_Ok_Click_02(object sender, EventArgs e)
        {
            //Verschieben des Elements in der sender-Variablen um 100 Pixel nach rechts
            (sender as Button).Left += 100;
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Aufruf einer MessageBox
            DialogResult result = MessageBox.Show("Möchtest du wirklich das Programm beenden?", "Beenden", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //Prüfung des geklickten Buttons
            if (result == DialogResult.Yes)
                //Schließend des Fensters
                this.Close();

            //Schließend der Applikation
            //Application.Exit();
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Instanziieren eines neuen Forms
            MainWindow neuesFenster = new MainWindow();
            //Öffen des Forms als Dialogfenster (muss exklusiv bearbeitet werden)
            neuesFenster.ShowDialog();
            //Öffnen des Forms als gleichberechtigtes Fenster
            neuesFenster.Show();
        }
    }
}
