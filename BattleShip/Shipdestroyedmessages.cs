using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShip
{
    class Shipdestroyedmessages
    {
        //δημιουργια συναρτησης οπου δεχετει εναν αριθμο ο οποιος αντιστοιχει σε ποιο καραβι αναφερομαστε και στο αντιστοιχο μηνυμα αν ειναι Μπαβο ή Δυστυχως
        public void print_result(int x, string y)
        {
            if (x == 2)
            {
                MessageBox.Show("Μόλις Κατατράφηκε ένα ΥΠΟΒΡΥΧΙΟ", y);
            }
            else if (x == 3)
            {
                MessageBox.Show("Μόλις Κατατράφηκε ένα ΠΟΛΕΜΙΚΟ", y);
            }
            else if (x == 4)
            {
                MessageBox.Show("Μόλις Κατατράφηκε ένα ΑΝΤΙΡΤΟΠΟΙΛΙΚΟ", y);
            }
            else if (x == 5)
            {
                MessageBox.Show("Μόλις Κατατράφηκε ένα ΑΕΡΟΠΛΑΝΟΦΟΡΟ", y);
            }
            else //ΑΝ ΔΕΝ ΔΩΣΟΥΜΕ ΣΗΜΕΙΟ ΕΜΦΑΝΙΖΕΤΑΙ ΜΗΝΥΜΑ
            {
                MessageBox.Show("Επέλεξε Σημείο απο το Drop-Down", "Προσοχή!");
            }
        }
    }
}
