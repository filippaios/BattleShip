using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace BattleShip
{
    public class Messageprinter
    {
        //δημιουργια συναρτησεων  για την εμφανιση του αντιστοιχου μηνυματος
        public int  result_print_X(int playerScore, int enemyScore, int round, int player_total_win, int enemy_total_win)
        {
            DialogResult result = MessageBox.Show("Ισοπαλία!" + "\n" +
                     "ΣΚΟΡ-->" + "" + playerScore + "-" + enemyScore + "\n" +
                     "ΓΥΡΟΙ-->" + "" + round + "\n"
                     + "Συνολικό Σκορ -->" + player_total_win + "-" + enemy_total_win + "\n" + "\n"
                     + "Θέλεις να ξεκινήσεις απο την Αρχή ?",
                 "Τέλος Παιχνιδιού",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int result_print_L(int playerScore, int enemyScore, int round, int player_total_win, int enemy_total_win)
        {
            DialogResult result = MessageBox.Show("Δυστυχώς Έχασες!" + "\n" +
                         "ΣΚΟΡ-->" + "" + playerScore + "-" + enemyScore + "\n" +
                        "ΓΥΡΟΙ-->" + "" + round + "\n"
                        + "Συνολικό Σκορ -->" + player_total_win + "-" + enemy_total_win + "\n" + "\n"
                        + "Θέλεις να ξεκινήσεις απο την Αρχή ?",
                    "Τέλος Παιχνιδιού",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int result_print_W(int playerScore, int enemyScore, int round, int player_total_win, int enemy_total_win)
        {
            DialogResult result = MessageBox.Show("Συγχαρητήρια Κέρδισες!" + "\n" +
                "ΣΚΟΡ-->" + "" + playerScore + "-" + enemyScore + "\n" +
                 "ΓΥΡΟΙ-->" + "" + round + "\n"
                + "Συνολικό Σκορ -->" + player_total_win + "-" + enemy_total_win + "\n" + "\n"
                + "Θέλεις να ξεκινήσεις απο την Αρχή ?",
                "Τέλος Παιχνιδιού",
             MessageBoxButtons.YesNo,
            MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
