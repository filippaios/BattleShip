using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }
        //ΤΟ ΠΑΙΧΝΙΔΙ ΞΕΚΙΝΑΕΙ ΜΕ ΤΗΝ ΚΑΤΩΘΙ ΣΕΙΡΑΣ >
        //1)ΔΗΛΩΣΗ ΜΕΤΑΒΛΗΤΩΝ 2)ΣΥΝΑΡΤΗΣΗ ΣΤΗΝ ΟΠΟΙΑ ΑΡΧΙΚΟΠΟΙΟΥΝΤΑΙ ΟΙ ΜΕΤΑΒΛΗΤΕΣ(RESTART GAME)
        // 3)RANDOM ΕΠΙΛΟΓΗ ΘΕΣΕΩΝ ΑΠΟ ΤΟΝ ΑΝΤΙΠΑΛΙ (enemyLocationPicker)
        // 4)RANDOM ΕΠΙΛΟΓΗ ΘΕΣΕΩΝ ΑΠΟ ΤΟΝ ΑΝΤΙΠΑΛΙ (playerLocationPicker)
        //5) ενεργειες του κομπιού attack (AttackButtonEvent)
        //6) επιθεση απο αντίπαλο (EnemyPlayTimerEvent)     


        //ΔΗΛΩΣΗ ΜΕΤΑΒΛΗΤΩΝ
        List<Button> playerPositionButtons;
        List<Button> enemyPositionButtons;
        List<string> diataksi;

        Random rand = new Random();

        int player_total_win = 0;
        int enemy_total_win = 0;

        int round;//μεταβλητη που δειχνει σε ποιο γυρο βρισκομαστε
       //μεταβλητες που δειχνουν το σκορ του καθε παικτη μετα απο καθε γυρο
        int playerScore;
        int enemyScore;

        //αρχικοποίηση μεταβλητών για την αρχικοποιηση του αριθμου κουμπιων που θα πιανουν καθε πλοιο
        int player_aeroplanoforo;
        int player_antirtopiliko;
        int player_polemiko;
        int player_upovrixio;

        int enemy_aeroplanoforo;
        int enemy_antirtopiliko;
        int enemy_polemiko;
        int enemy_upovrixio;

        Model1Container container = new Model1Container();

        private void RestartGame()
        {
            //Λιστα με 2 στοιχεια. Ωστε να γινεται η επιλογη Random τοποθετησης καραβιων ειτε απο εμας ειτε απο εχθρο.
            diataksi = new List<string> { "katheta", "orizontia" };

            //Δημιουργία λίστας με τα κουμπιά του εχθρού
            enemyPositionButtons = new List<Button> { k1,k2,k3,k4,k5,k6,k7,k8,k9,k10,
            l1,l2,l3,l4,l5,l6,l7,l8,l9,l10,
            m1,m2,m3,m4,m5,m6,m7,m8,m9,m10,
            n1,n2,n3,n4,n5,n6,n7,n8,n9,n10,
            o1,o2,o3,o4,o5,o6,o7,o8,o9,o10,
            p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,
            q1,q2,q3,q4,q5,q6,q7,q8,q9,q10,
            r1,r2,r3,r4,r5,r6,r7,r8,r9,r10,
            s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,
            t1,t2,t3,t4,t5,t6,t7,t8,t9,t10

            };

            //Δημιουργία λίστας με τα δικά μας κουμπιά
            playerPositionButtons = new List<Button> { A1, A2, A3, A4,A5,A6,A7,A8,A9,A10,
                B1,B2,B3,B4,B5,B6,B7,B8,B9,B10,
                C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,
                D1,D2,D3,D4,D5,D6,D7,D8,D9,D10,
                E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,
                F1,F2,F3,F4,F5,F6,F7,F8,F9,F10,
                G1,G2,G3,G4,G5,G6,G7,G8,G9,G10,
                H1,H2,H3,H4,H5,H6,H7,H8,H9,H10,
                I1,I2,I3,I4,I5,I6,I7,I8,I9,I10,
                J1,J2,J3,J4,J5,J6,J7,J8,J9,J10
            };

            //Αυτο ειναι το compobox στο οποια επιλεγουμε το σημειο επίθεσης στον αντιπαλο. Στην αρχικοποιηση του παιχνιδιου καθως και
            //σε περιπτωση restart του παιχνιδιου το κανουμε clear και null για να μην εμφανιζεται κανενα σημειο.  
            EnemyLocationListBox.Items.Clear();
            EnemyLocationListBox.Text = null;
           
            //Βαζουμε χαρακτηριστικα στα κουμπιά του αντιπάλου.Όπως τα κανουμε enable, λευκά, χωρις εικονα στο backgroug, Και χωρις καποιο tag
            for (int i = 0; i < enemyPositionButtons.Count; i++)
            {
                enemyPositionButtons[i].Enabled = true;
                enemyPositionButtons[i].Tag = null;
                enemyPositionButtons[i].BackColor = Color.White;
                enemyPositionButtons[i].BackgroundImage = null;
                //Προσθετουμε τα στοιχεια απο την λιστα στο compobox που εχουμε για να διαλεγουμε τα σημεια αντιπάλου προς επιθεση
                EnemyLocationListBox.Items.Add(enemyPositionButtons[i].Text);
            }

            // //Βαζουμε χαρακτηριστικα στα κουμπιά τα δικά μας αυτη την φορά
            for (int i = 0; i < playerPositionButtons.Count; i++)
            {
                playerPositionButtons[i].Enabled = true;
                playerPositionButtons[i].Tag = null;
                playerPositionButtons[i].BackColor = Color.White;
                playerPositionButtons[i].BackgroundImage = null;
            }
            //Αρχικοποιηση γυρων, σκορ
            playerScore = 0;
            enemyScore = 0;
            round = 0;

            //Αρχικοποιηση  αριθμου κουμπιων που πιανει το καθε πλοιο του καθε παικτη
            player_aeroplanoforo = 5;
            player_antirtopiliko = 4;
            player_polemiko = 3;
            player_upovrixio = 2;

            enemy_aeroplanoforo = 5;
            enemy_antirtopiliko = 4;
            enemy_polemiko = 3;
            enemy_upovrixio = 2;

            //τα κειμενακια στην οθονη που δειχνουν το σκορ κάθε παιχτη. 
            txtPlayer.Text = playerScore.ToString();
            txtEnemy.Text = enemyScore.ToString();
            txtRounds.Text = round.ToString();

            //Το κειμενακι που δειχνει την κίνηση του αντιπάλου.
            enemyMove.Text = "-";

            //Εδω καλειται η συναρτηση ωστε να ξεκινησει η επιλογη θέσεων απο τον αντίπαλο.
            enemyLocationPicker();
        }

        //συναρτηση ωστε να ξεκινησει η επιλογη θέσεων απο τον αντίπαλο.
        //η συναρτηση αυτη αρχικοποιει σε ποια κουμπια θα βρισκονται τα πλοια του αντιπαλου
        private void enemyLocationPicker()
        {
            //AEROPLANOFORO

            //random επιλογη διαταξης πλοιων
            //απο τον πινακα diataksi παιρνω τον αριθμο των στοιχειων που εχει 
            int diataksi_aeroplanoforwn = rand.Next(diataksi.Count);
            if (diataksi_aeroplanoforwn == 1) //Αν ειναι η διαταξη οριζόντια
            {
                //μεταβλητη που αποθηκευει το τυχαιο σημειο οπου θα ξεκινησει η τοποθετηση των κουμπιων που αντιστοιχουν για το πλοιο αεροπλανοφορο
                int tuxaio_aeroplanodoro;  
                do
                {
                    //επλογη τυχαιου κουμπιου απο την λιστα enemyPositionButtons και αφαιρω 5 θέσεις(γιατι τοσο πιανει το αεροπλανοφορο) απο τον αριθμο
                    //που βρηκα για να μπορεσω να κανω στη συνεχεια τους ελεγχους για τα tag  
                    tuxaio_aeroplanodoro = rand.Next(enemyPositionButtons.Count - 5);
                   
                } while ( ((string)enemyPositionButtons[tuxaio_aeroplanodoro].Tag != null) && ((string)enemyPositionButtons[tuxaio_aeroplanodoro + 1].Tag != null)
                && ((string)enemyPositionButtons[tuxaio_aeroplanodoro + 2].Tag != null) && ((string)enemyPositionButtons[tuxaio_aeroplanodoro + 3].Tag != null)
                && ((string)enemyPositionButtons[tuxaio_aeroplanodoro + 4].Tag != null)); //ελεγχει αν στα επομενα 5 κουμπια υπάρχει άλλο πλοιο. Τοτε μόνο θα σταματησει το loop. 

                //Στα 5 κουμπια που βρηκε ελευθερα βαζει tag το χρησιμοποιουμε για να εχουν ονομασια τα κουμπια για να γινεται ο ελεγχος
                //το καθε κουμπι σε ποιο πλοιο αντιστοιχει
                enemyPositionButtons[tuxaio_aeroplanodoro].Tag = "enemy_aeroplanoforo"; 
                enemyPositionButtons[tuxaio_aeroplanodoro + 1].Tag = "enemy_aeroplanoforo";
                enemyPositionButtons[tuxaio_aeroplanodoro + 2].Tag = "enemy_aeroplanoforo";
                enemyPositionButtons[tuxaio_aeroplanodoro + 3].Tag = "enemy_aeroplanoforo";
                enemyPositionButtons[tuxaio_aeroplanodoro + 4].Tag = "enemy_aeroplanoforo";

            }
            else //αν η διαταξη ειναι καθετα 
            //Η διαδικασια ειναι ιδια με τα οριζοντια με την διαφορα οτι ελεγχει τα κουμπια +10,+20. Αυτο γινεται γιατι το κουμπι στην απο κατω σειρά
            // ειναι 10 θεσεις μετά. 
            {
                int tuxaio_aeroplanodoro;
                do
                {
                    tuxaio_aeroplanodoro = rand.Next(enemyPositionButtons.Count - 40);
                } while ((string)enemyPositionButtons[tuxaio_aeroplanodoro].Tag != null && (string)enemyPositionButtons[tuxaio_aeroplanodoro + 10].Tag != null
                && (string)enemyPositionButtons[tuxaio_aeroplanodoro + 20].Tag != null && (string)enemyPositionButtons[tuxaio_aeroplanodoro + 30].Tag != null
                && (string)enemyPositionButtons[tuxaio_aeroplanodoro + 40].Tag != null);

                enemyPositionButtons[tuxaio_aeroplanodoro].Tag = "enemy_aeroplanoforo";
                enemyPositionButtons[tuxaio_aeroplanodoro + 10].Tag = "enemy_aeroplanoforo";
                enemyPositionButtons[tuxaio_aeroplanodoro + 20].Tag = "enemy_aeroplanoforo";
                enemyPositionButtons[tuxaio_aeroplanodoro + 30].Tag = "enemy_aeroplanoforo";
                enemyPositionButtons[tuxaio_aeroplanodoro + 40].Tag = "enemy_aeroplanoforo";
            }

            //ANTIRTOPOILIKO
            //random επιλογη διαταξης πλοιων
            int diataksi_antirtopoilikwn = rand.Next(diataksi.Count);
            if (diataksi_antirtopoilikwn == 1) //Αν ειναι η διαταξη οριζόντια
            {
                int tuxaio_antirtopoiliko;
        
                do
                {
                    tuxaio_antirtopoiliko = rand.Next(enemyPositionButtons.Count - 4);//επλογη τυχαιου κουμπιου απο την λιστα enemyPositionButtons

                } while (((string)enemyPositionButtons[tuxaio_antirtopoiliko].Tag != null) && ((string)enemyPositionButtons[tuxaio_antirtopoiliko + 1].Tag != null) && ((string)enemyPositionButtons[tuxaio_antirtopoiliko + 2].Tag != null) && ((string)enemyPositionButtons[tuxaio_antirtopoiliko + 3].Tag != null));
                //ελεγχει αν στα επομενα 4 κουμπια υπάρχει άλλο πλοιο. Τοτε μόνο θα σταματησει το loop. 

                //Στα 4 κουμπια που βρηκε ελευθερα βαζει tag
                enemyPositionButtons[tuxaio_antirtopoiliko].Tag = "enemy_antirtopoiliko";
                enemyPositionButtons[tuxaio_antirtopoiliko + 1].Tag = "enemy_antirtopoiliko";
                enemyPositionButtons[tuxaio_antirtopoiliko + 2].Tag = "enemy_antirtopoiliko";
                enemyPositionButtons[tuxaio_antirtopoiliko + 3].Tag = "enemy_antirtopoiliko";

            }
            else//αν η διαταξη ειναι καθετα 
            {
                //Η διαδικασια ειναι ιδια με τα οριζοντια με την διαφορα οτι ελεγχει τα κουμπια +10,+20. Αυτο γινεται γιατι το κουμπι στην απο κατω σειρά
                // ειναι 10 θεσεις μετά. 
                int tuxaio_antirtopoiliko;
                do
                {
                    tuxaio_antirtopoiliko = rand.Next(enemyPositionButtons.Count - 30);

                } while ((string)enemyPositionButtons[tuxaio_antirtopoiliko].Tag != null && (string)enemyPositionButtons[tuxaio_antirtopoiliko + 10].Tag != null
                && (string)enemyPositionButtons[tuxaio_antirtopoiliko + 20].Tag != null && (string)enemyPositionButtons[tuxaio_antirtopoiliko + 30].Tag != null);

                enemyPositionButtons[tuxaio_antirtopoiliko].Tag = "enemy_antirtopoiliko";
                enemyPositionButtons[tuxaio_antirtopoiliko + 10].Tag = "enemy_antirtopoiliko";
                enemyPositionButtons[tuxaio_antirtopoiliko + 20].Tag = "enemy_antirtopoiliko";
                enemyPositionButtons[tuxaio_antirtopoiliko + 30].Tag = "enemy_antirtopoiliko";
            }

            //POLEMIKO
            int diataksi_polemikwn = rand.Next(diataksi.Count);
            if (diataksi_polemikwn == 1)
            {
                int tuxaio_polemiko;
          
                do
                {
                    tuxaio_polemiko = rand.Next(enemyPositionButtons.Count - 3);

                } while (((string)enemyPositionButtons[tuxaio_polemiko].Tag != null) && ((string)enemyPositionButtons[tuxaio_polemiko + 1].Tag != null) && ((string)enemyPositionButtons[tuxaio_polemiko + 2].Tag != null));

                enemyPositionButtons[tuxaio_polemiko].Tag = "enemy_polemiko";
                enemyPositionButtons[tuxaio_polemiko + 1].Tag = "enemy_polemiko";
                enemyPositionButtons[tuxaio_polemiko + 2].Tag = "enemy_polemiko";

            }
            else
            {
                int tuxaio_polemiko;
                do
                {
                    tuxaio_polemiko = rand.Next(enemyPositionButtons.Count - 20);
                } while ((string)enemyPositionButtons[tuxaio_polemiko].Tag != null && (string)enemyPositionButtons[tuxaio_polemiko + 10].Tag != null
                && (string)enemyPositionButtons[tuxaio_polemiko + 20].Tag != null);

                enemyPositionButtons[tuxaio_polemiko].Tag = "enemy_polemiko";
                enemyPositionButtons[tuxaio_polemiko + 10].Tag = "enemy_polemiko";
                enemyPositionButtons[tuxaio_polemiko + 20].Tag = "enemy_polemiko";
            }

            //YPOVRIXIO
            int diataksi_upovrixion = rand.Next(diataksi.Count);
            if (diataksi_upovrixion == 1)
            {
                int tuxaio_upovrixio;
                
                do
                {
                    tuxaio_upovrixio = rand.Next(enemyPositionButtons.Count - 2);
            
                } while (((string)enemyPositionButtons[tuxaio_upovrixio].Tag != null) && ((string)enemyPositionButtons[tuxaio_upovrixio + 1].Tag != null));

                enemyPositionButtons[tuxaio_upovrixio].Tag = "enemy_upovrixio";
                enemyPositionButtons[tuxaio_upovrixio + 1].Tag = "enemy_upovrixio";
            }
            else
            {
                int tuxaio_upovrixio;
                do
                {
                    tuxaio_upovrixio = rand.Next(enemyPositionButtons.Count - 10);
                } while ((string)enemyPositionButtons[tuxaio_upovrixio].Tag != null && (string)enemyPositionButtons[tuxaio_upovrixio + 10].Tag != null);

                enemyPositionButtons[tuxaio_upovrixio].Tag = "enemy_upovrixio";
                enemyPositionButtons[tuxaio_upovrixio + 10].Tag = "enemy_upovrixio";
            }
          
            //ΕΔΩ Καλειται η συναρτηση ωστε να ξεκινησει η ιδια ακριβως διαδικασια αλλα στα κουμπια του Player ( τα δικα μας δηλαδη).
            playerLocationPicker();
        }
       // συναρτηση ωστε να ξεκινησει η ιδια ακριβως διαδικασια αλλα στα κουμπια του Player(τα δικα μας δηλαδη)
       //η συναρτηση αυτη αρχικοποιει σε ποια κουμπια θα βρισκονται τα πλοια
        private void playerLocationPicker()
        {
         
            //AEROPLANOFORO
            int diataksi_aeroplanoforwn = rand.Next(diataksi.Count);
            if (diataksi_aeroplanoforwn == 1)
            {
                
                int tuxaio_aeroplanodoro;
                do
                {
                    tuxaio_aeroplanodoro = rand.Next(playerPositionButtons.Count - 5);

                } while ( (string)playerPositionButtons[tuxaio_aeroplanodoro].Tag != null && (string)playerPositionButtons[tuxaio_aeroplanodoro + 1].Tag != null
                && (string)playerPositionButtons[tuxaio_aeroplanodoro + 2].Tag != null && (string)playerPositionButtons[tuxaio_aeroplanodoro + 3].Tag != null
                && (string)playerPositionButtons[tuxaio_aeroplanodoro + 4].Tag != null);

                playerPositionButtons[tuxaio_aeroplanodoro].Tag = "player_aeroplanoforo";
                playerPositionButtons[tuxaio_aeroplanodoro + 1].Tag = "player_aeroplanoforo";
                playerPositionButtons[tuxaio_aeroplanodoro + 2].Tag = "player_aeroplanoforo";
                playerPositionButtons[tuxaio_aeroplanodoro + 3].Tag = "player_aeroplanoforo";
                playerPositionButtons[tuxaio_aeroplanodoro + 4].Tag = "player_aeroplanoforo";

                //Η ΔΙΑΔΙΚΑ ΕΙΝΑΙ ΙΔΙΑ ΜΕ ΤΑ ΚΟΥΜΠΙΑ ΤΟΥ ΑΝΤΙΠΑΛΟΥ ΜΕ ΤΗΝ ΔΙΑΦΟΡΑ ΟΤΙ ΣΤΑ ΔΙΚΑ ΜΑς ΘΑ ΕΧΟΥΜΕ ΕΝΑ ΜΠΛΕ ΠΛΟΙΟ ΓΙΑ BACKGROUD ΣΤΑ ΚΟΥΜΠΙΑ
                //ΩΣΤΕ ΝΑ ΒΛΕΠΟΥΜΕ ΠΟΥ ΕΙΝΑΙ.
                playerPositionButtons[tuxaio_aeroplanodoro].BackgroundImage = BattleShip.Properties.Resources.ship_blue;
                playerPositionButtons[tuxaio_aeroplanodoro + 1].BackgroundImage = BattleShip.Properties.Resources.ship_blue;
                playerPositionButtons[tuxaio_aeroplanodoro + 2].BackgroundImage = BattleShip.Properties.Resources.ship_blue;
                playerPositionButtons[tuxaio_aeroplanodoro + 3].BackgroundImage = BattleShip.Properties.Resources.ship_blue;
                playerPositionButtons[tuxaio_aeroplanodoro + 4].BackgroundImage = BattleShip.Properties.Resources.ship_blue;
            }
            else
            {
                int tuxaio_aeroplanodoro;
                do
                {
                    tuxaio_aeroplanodoro = rand.Next(playerPositionButtons.Count - 40);
                } while ((string)playerPositionButtons[tuxaio_aeroplanodoro].Tag != null && (string)playerPositionButtons[tuxaio_aeroplanodoro + 10].Tag != null
                && (string)playerPositionButtons[tuxaio_aeroplanodoro + 20].Tag != null && (string)playerPositionButtons[tuxaio_aeroplanodoro + 30].Tag != null
                && (string)playerPositionButtons[tuxaio_aeroplanodoro + 40].Tag != null);

                playerPositionButtons[tuxaio_aeroplanodoro].Tag = "player_aeroplanoforo";
                playerPositionButtons[tuxaio_aeroplanodoro + 10].Tag = "player_aeroplanoforo";
                playerPositionButtons[tuxaio_aeroplanodoro + 20].Tag = "player_aeroplanoforo";
                playerPositionButtons[tuxaio_aeroplanodoro + 30].Tag = "player_aeroplanoforo";
                playerPositionButtons[tuxaio_aeroplanodoro + 40].Tag = "player_aeroplanoforo";

                //Η ΔΙΑΔΙΚΑ ΕΙΝΑΙ ΙΔΙΑ ΜΕ ΤΑ ΚΟΥΜΠΙΑ ΤΟΥ ΑΝΤΙΠΑΛΟΥ ΜΕ ΤΗΝ ΔΙΑΦΟΡΑ ΟΤΙ ΣΤΑ ΔΙΚΑ ΜΑς ΘΑ ΕΧΟΥΜΕ ΕΝΑ ΜΠΛΕ ΠΛΟΙΟ ΓΙΑ BACKGROUD ΣΤΑ ΚΟΥΜΠΙΑ
                //ΩΣΤΕ ΝΑ ΒΛΕΠΟΥΜΕ ΠΟΥ ΕΙΝΑΙ.
                playerPositionButtons[tuxaio_aeroplanodoro].BackgroundImage = BattleShip.Properties.Resources.ship_blue;
                playerPositionButtons[tuxaio_aeroplanodoro + 10].BackgroundImage = BattleShip.Properties.Resources.ship_blue;
                playerPositionButtons[tuxaio_aeroplanodoro + 20].BackgroundImage = BattleShip.Properties.Resources.ship_blue;
                playerPositionButtons[tuxaio_aeroplanodoro + 30].BackgroundImage = BattleShip.Properties.Resources.ship_blue;
                playerPositionButtons[tuxaio_aeroplanodoro + 40].BackgroundImage = BattleShip.Properties.Resources.ship_blue;
            }

            //ANTIRTOPOILIKO
            int diataksi_antirtopoilikwn = rand.Next(diataksi.Count);
            if (diataksi_antirtopoilikwn == 1)
            {
                int tuxaio_antirtopoiliko;
                
                do
                {
                    tuxaio_antirtopoiliko = rand.Next(playerPositionButtons.Count - 4);
            
                } while ( (string)playerPositionButtons[tuxaio_antirtopoiliko].Tag != null && (string)playerPositionButtons[tuxaio_antirtopoiliko + 1].Tag != null
                && (string)playerPositionButtons[tuxaio_antirtopoiliko + 2].Tag != null && (string)playerPositionButtons[tuxaio_antirtopoiliko + 3].Tag != null);

                playerPositionButtons[tuxaio_antirtopoiliko].Tag = "player_antirtopoiliko";
                playerPositionButtons[tuxaio_antirtopoiliko + 1].Tag = "player_antirtopoiliko";
                playerPositionButtons[tuxaio_antirtopoiliko + 2].Tag = "player_antirtopoiliko";
                playerPositionButtons[tuxaio_antirtopoiliko + 3].Tag = "player_antirtopoiliko";

                //Η ΔΙΑΔΙΚΑ ΕΙΝΑΙ ΙΔΙΑ ΜΕ ΤΑ ΚΟΥΜΠΙΑ ΤΟΥ ΑΝΤΙΠΑΛΟΥ ΜΕ ΤΗΝ ΔΙΑΦΟΡΑ ΟΤΙ ΣΤΑ ΔΙΚΑ ΜΑς ΘΑ ΕΧΟΥΜΕ ΕΝΑ ΜΠΛΕ ΠΛΟΙΟ ΓΙΑ BACKGROUD ΣΤΑ ΚΟΥΜΠΙΑ
                //ΩΣΤΕ ΝΑ ΒΛΕΠΟΥΜΕ ΠΟΥ ΕΙΝΑΙ.
                playerPositionButtons[tuxaio_antirtopoiliko].BackgroundImage = BattleShip.Properties.Resources.ship_green;
                playerPositionButtons[tuxaio_antirtopoiliko + 1].BackgroundImage = BattleShip.Properties.Resources.ship_green;
                playerPositionButtons[tuxaio_antirtopoiliko + 2].BackgroundImage = BattleShip.Properties.Resources.ship_green;
                playerPositionButtons[tuxaio_antirtopoiliko + 3].BackgroundImage = BattleShip.Properties.Resources.ship_green;

                playerPositionButtons[tuxaio_antirtopoiliko].BackgroundImageLayout = ImageLayout.Center;
                playerPositionButtons[tuxaio_antirtopoiliko + 1].BackgroundImageLayout = ImageLayout.Center;
                playerPositionButtons[tuxaio_antirtopoiliko + 2].BackgroundImageLayout = ImageLayout.Center;
                playerPositionButtons[tuxaio_antirtopoiliko + 3].BackgroundImageLayout = ImageLayout.Center;
            }
            else
            {
                int tuxaio_antirtopoiliko;
                do
                {
                    tuxaio_antirtopoiliko = rand.Next(playerPositionButtons.Count - 30);
                } while ((string)playerPositionButtons[tuxaio_antirtopoiliko].Tag != null && (string)playerPositionButtons[tuxaio_antirtopoiliko + 10].Tag != null
                && (string)playerPositionButtons[tuxaio_antirtopoiliko + 20].Tag != null && (string)playerPositionButtons[tuxaio_antirtopoiliko + 30].Tag != null);

                playerPositionButtons[tuxaio_antirtopoiliko].Tag = "player_antirtopoiliko";
                playerPositionButtons[tuxaio_antirtopoiliko + 10].Tag = "player_antirtopoiliko";
                playerPositionButtons[tuxaio_antirtopoiliko + 20].Tag = "player_antirtopoiliko";
                playerPositionButtons[tuxaio_antirtopoiliko + 30].Tag = "player_antirtopoiliko";

                playerPositionButtons[tuxaio_antirtopoiliko].BackgroundImage = BattleShip.Properties.Resources.ship_green;
                playerPositionButtons[tuxaio_antirtopoiliko + 10].BackgroundImage = BattleShip.Properties.Resources.ship_green;
                playerPositionButtons[tuxaio_antirtopoiliko + 20].BackgroundImage = BattleShip.Properties.Resources.ship_green;
                playerPositionButtons[tuxaio_antirtopoiliko + 30].BackgroundImage = BattleShip.Properties.Resources.ship_green;

                playerPositionButtons[tuxaio_antirtopoiliko].BackgroundImageLayout = ImageLayout.Center;
                playerPositionButtons[tuxaio_antirtopoiliko + 10].BackgroundImageLayout = ImageLayout.Center;
                playerPositionButtons[tuxaio_antirtopoiliko + 20].BackgroundImageLayout = ImageLayout.Center;
                playerPositionButtons[tuxaio_antirtopoiliko + 30].BackgroundImageLayout = ImageLayout.Center;
            }

            //POLEMIKO
            int diataksi_polemikwn = rand.Next(diataksi.Count);
            if (diataksi_polemikwn == 1)
            {
                int tuxaio_polemiko;
              
                do
                {
                    tuxaio_polemiko = rand.Next(playerPositionButtons.Count -3);
                 
                } while ( (string)playerPositionButtons[tuxaio_polemiko].Tag != null && (string)playerPositionButtons[tuxaio_polemiko + 1].Tag != null
                && (string)playerPositionButtons[tuxaio_polemiko + 2].Tag != null);

                playerPositionButtons[tuxaio_polemiko].Tag = "player_polemiko";
                playerPositionButtons[tuxaio_polemiko + 1].Tag = "player_polemiko";
                playerPositionButtons[tuxaio_polemiko + 2].Tag = "player_polemiko";

                playerPositionButtons[tuxaio_polemiko].BackgroundImage = BattleShip.Properties.Resources.ship_yellow;
                playerPositionButtons[tuxaio_polemiko + 1].BackgroundImage = BattleShip.Properties.Resources.ship_yellow;
                playerPositionButtons[tuxaio_polemiko + 2].BackgroundImage = BattleShip.Properties.Resources.ship_yellow;

                playerPositionButtons[tuxaio_polemiko].BackgroundImageLayout = ImageLayout.Center;
                playerPositionButtons[tuxaio_polemiko + 1].BackgroundImageLayout = ImageLayout.Center;
                playerPositionButtons[tuxaio_polemiko + 2].BackgroundImageLayout = ImageLayout.Center;


            }
            else
            {
                int tuxaio_polemiko;
                do
                {
                    tuxaio_polemiko = rand.Next(playerPositionButtons.Count - 20);
                } while ((string)playerPositionButtons[tuxaio_polemiko].Tag != null && (string)playerPositionButtons[tuxaio_polemiko + 10].Tag != null
                && (string)playerPositionButtons[tuxaio_polemiko + 20].Tag != null);

                playerPositionButtons[tuxaio_polemiko].Tag = "player_polemiko";
                playerPositionButtons[tuxaio_polemiko + 10].Tag = "player_polemiko";
                playerPositionButtons[tuxaio_polemiko + 20].Tag = "player_polemiko";

                playerPositionButtons[tuxaio_polemiko].BackgroundImage = BattleShip.Properties.Resources.ship_yellow;
                playerPositionButtons[tuxaio_polemiko + 10].BackgroundImage = BattleShip.Properties.Resources.ship_yellow;
                playerPositionButtons[tuxaio_polemiko + 20].BackgroundImage = BattleShip.Properties.Resources.ship_yellow;

                playerPositionButtons[tuxaio_polemiko].BackgroundImageLayout = ImageLayout.Center;
                playerPositionButtons[tuxaio_polemiko + 10].BackgroundImageLayout = ImageLayout.Center;
                playerPositionButtons[tuxaio_polemiko + 20].BackgroundImageLayout = ImageLayout.Center;
            }

            //YPOVRIXIO
            int diataksi_upovrixion = rand.Next(diataksi.Count);
            if (diataksi_upovrixion == 1)
            {
                int tuxaio_upovrixio;
              
                do
                {
                    tuxaio_upovrixio = rand.Next(playerPositionButtons.Count - 2);
                  
                } while ((string)playerPositionButtons[tuxaio_upovrixio].Tag != null && (string)playerPositionButtons[tuxaio_upovrixio + 1].Tag != null);

                playerPositionButtons[tuxaio_upovrixio].Tag = "player_upovrixio";
                playerPositionButtons[tuxaio_upovrixio + 1].Tag = "player_upovrixio";

                playerPositionButtons[tuxaio_upovrixio].BackgroundImage = BattleShip.Properties.Resources.ship_purple;
                playerPositionButtons[tuxaio_upovrixio + 1].BackgroundImage = BattleShip.Properties.Resources.ship_purple;

                playerPositionButtons[tuxaio_upovrixio].BackgroundImageLayout = ImageLayout.Center;
                playerPositionButtons[tuxaio_upovrixio + 1].BackgroundImageLayout = ImageLayout.Center;

            }
            else
            {
                int tuxaio_upovrixio;
                do
                {
                    tuxaio_upovrixio = rand.Next(playerPositionButtons.Count - 10);
                } while ((string)playerPositionButtons[tuxaio_upovrixio].Tag != null && (string)playerPositionButtons[tuxaio_upovrixio + 10].Tag != null);
                
                playerPositionButtons[tuxaio_upovrixio].Tag = "player_upovrixio";
                playerPositionButtons[tuxaio_upovrixio + 10].Tag = "player_upovrixio";

                playerPositionButtons[tuxaio_upovrixio].BackgroundImage = BattleShip.Properties.Resources.ship_purple;
                playerPositionButtons[tuxaio_upovrixio + 10].BackgroundImage = BattleShip.Properties.Resources.ship_purple;

                playerPositionButtons[tuxaio_upovrixio].BackgroundImageLayout = ImageLayout.Center;
                playerPositionButtons[tuxaio_upovrixio + 10].BackgroundImageLayout = ImageLayout.Center;
            }

        }


    //ΕΝΕΡΓΕΙΑ ΚΟΥΜΠΙΟΥ ATTACK
        private void AttackButtonEvent(object sender, EventArgs e)
        {
            //ΕΛΕΓΧΕΙ ΩΣΤΕ ΝΑ ΕΧΟΥΜΕ ακομη στοιχεια στην λιστα
            if (EnemyLocationListBox.Text != "")
            {
                //και η μεταβλητη αυτη αποθηκευει την επιλογη μας
                var attackPosition = EnemyLocationListBox.Text.ToLower(); //ΕΜΦΑΝΙΖΕΙ ΤΗΝ ΛΙΣΤΑ ΜΕ ΤΑ ΚΟΥΜΠΙΑ ΑΝΤΙΠΑΛΟΥ ΜΕ ΑΥΞΟΥΣΑ ΣΕΙΡΑ
                //η μεταβλητη αυτη αποθηκευει την επιλογη μας απο την λιστα
                int index = enemyPositionButtons.FindIndex(a => a.Name == attackPosition); //ΨΑΧΝΕΙ ΤΟ ΚΟΥΜΠΙ ΠΟΥ ΤΟΥ ΔΩΣΑΜΕ ΣΤΗΝ ΛΊΣΤΑ ΚΟΥΜΠΙΩΝ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
                //ΟΤΑΝ ΤΟ ΒΡΕΙ, ΠΑΙΡΝΕΙ ΤΟ ΑΡΙΘΜΟ ΤΟΥ ΚΑΙ ΤΟΝ ΚΑΤΑΧΩΡΕΙ ΣΕ ΜΙΑ ΜΕΤΑΒΛΗΤΗ int με ονομα index.

                if (enemyPositionButtons[index].Enabled && round <= 86) //ΑΝ ΤΟ ΚΟΥΜΠΙ ΑΝΤΙΠΑΛΟΥ ΠΟΥ ΔΩΣΑΜΕ ΕΙΝΑΙ ΔΙΑΘΕΣΙΜΟ (ENABLE). ΔΗΛΑΔΗ ΝΑ ΜΗΝ ΤΟ ΕΧΟΥΜΕ ΞΑΝΑ ΔΩΣΕΙ Ή ΝΑ ΜΗΝ ΕΧΕΙ ΧΤΥΠΗΘΕΙ ΠΡΟΗΓΟΥΜΕΝΩΣ.
                {
                    round += 1; //ΑΝΕΒΑΖΟΥΜΕ ΤΟΝ ΓΥΡΟ +1
                    txtRounds.Text = round.ToString(); //ΤΟ ΚΑΤΑΧΩΡΟΥΜΕ ΣΤΟ LABEL ΤΗΣ ΟΘΟΝΗΣ

                    if ((string)enemyPositionButtons[index].Tag == "enemy_aeroplanoforo") //ΑΝ ΒΡΗΚΑΜΕ ΑΕΡΟΠΛΑΝΟΦΟΡΟ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
                    {
                        enemyPositionButtons[index].Enabled = false; //ΤΟ ΚΑΝΕΙ ΜΗ ΔΙΑΘΕΣΙΜΟ ΓΙΑ ΤΟ ΜΕΛΛΟΝ
                        enemyPositionButtons[index].BackgroundImage = Properties.Resources.X; //ΒΑΖΟΥΜΕ ΕΙΚΟΝΑ Χ
                        enemyPositionButtons[index].BackColor = Color.White; //το κανουμΕ ΛΕΥΚΟ
                        
                        enemyPositionButtons.RemoveAt(index); //ΤΟ ΔΙΑΓΡΑΦΟΥΜΕ ΑΠΟ ΤΗΝ ΛΙΣΤΑ ΚΟΥΜΠΙΩΝ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
                        EnemyLocationListBox.Items.RemoveAt(index); //ΤΟ ΔΙΑΓΡΑΦΟΥΜΕ ΑΠΟ ΤΟ COMBOBOX πΟΥ ΔΙΑΛΕΓΟΥΜΕ ΕΜΕΙΣ ΤΗΝ ΕΠΟΜΕΝΗ ΚΙΝΗΣΗ ΜΑΣ
                        enemy_aeroplanoforo--; //ΜΕΙΩΝΟΥΜΕ ΤΑ ΑΡΟΠΛΑΝΟΦΟΡΑ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
                        playerScore += 1;  //ΑΝΕΒΑΖΟΥΜΕ ΤΟ ΣΚΟΡ ΜΑΣ +1
                        txtPlayer.Text = playerScore.ToString(); //ΚΑΤΑΧΩΡΟΥΜΕ ΤΟ ΣΚΟΡ ΜΑΣ ΣΤΟ LABEL ΜΑΣ
                        if (enemy_aeroplanoforo == 0)  //ΑΝ ΒΡΗΚΑΜΕ ΟΛΑ ΤΑ ΑΕΡΟΠΛΑΝΟΦΟΡΑ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
                        {
                            // MessageBox.Show("Μόλις Κατατράφηκε ένα ΑΕΡΟΠΛΑΝΟΦΟΡΟ", "Μπράβο!!");
                            //δημιουργια αντικειμενου ship1 της κλασης Shipdestroyedmessages
                            //μετα καλειται η συναρτηση για την εμφανιση του αντιστοιχου μηνυματος
                            Shipdestroyedmessages ship1 = new Shipdestroyedmessages();
                            ship1.print_result(5, "Μπράβο!!");
                        }
                        EnemyPlayTimer.Start(); //ΞΕΚΙΝΑΕΙ Η ΣΕΙΡΑ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
                    }
                    else if ((string)enemyPositionButtons[index].Tag == "enemy_antirtopoiliko")  //ΑΚΟΛΟΥΘΟΥΝ ΤΑ ΙΔΙΑ ΜΕ ΤΟ ΑΕΡΟΠΛΑΝΟΦΟΡΟ ΑΠΛΑ ΣΕ ΠΕΡΙΠΤΩΣΗ ΠΟΥ ΒΡΕΙ ΑΝΤΙΡΤΟΠΟΙΛΙΚΟ
                    {
                        enemyPositionButtons[index].Enabled = false;
                        enemyPositionButtons[index].BackgroundImage = Properties.Resources.X;
                        enemyPositionButtons[index].BackColor = Color.White;                        
                        enemyPositionButtons.RemoveAt(index);
                        EnemyLocationListBox.Items.RemoveAt(index);
                        enemy_antirtopiliko--;
                        playerScore += 1;
                        txtPlayer.Text = playerScore.ToString();
                        if (enemy_antirtopiliko == 0)
                        {
                            // MessageBox.Show("Μόλις Κατατράφηκε ένα ΑΝΤΙΡΤΟΠΟΙΛΙΚΟ", "Μπράβο!!");
                            Shipdestroyedmessages ship1 = new Shipdestroyedmessages();
                            ship1.print_result(4, "Μπράβο!!");
                        }
                        EnemyPlayTimer.Start();//ΞΕΚΙΝΑΕΙ Η ΣΕΙΡΑ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
                    }
                    else if ((string)enemyPositionButtons[index].Tag == "enemy_polemiko")//ΑΚΟΛΟΥΘΟΥΝ ΤΑ ΙΔΙΑ ΑΠΛΑ ΣΕ ΠΕΡΙΠΤΩΣΗ ΠΟΛΕΜΙΚΟΥ
                    {
                        enemyPositionButtons[index].Enabled = false;
                        enemyPositionButtons[index].BackgroundImage = Properties.Resources.X;
                        enemyPositionButtons[index].BackColor = Color.White;                       
                        enemyPositionButtons.RemoveAt(index);
                        EnemyLocationListBox.Items.RemoveAt(index);
                        enemy_polemiko--;
                        playerScore += 1;
                        txtPlayer.Text = playerScore.ToString();
                        if (enemy_polemiko == 0)
                        {
                          //  MessageBox.Show("Μόλις Κατατράφηκε ένα ΠΟΛΕΜΙΚΟ", "Μπράβο!!");
                            Shipdestroyedmessages ship1 = new Shipdestroyedmessages();
                            ship1.print_result(3, "Μπράβο!!");
                        }

                        EnemyPlayTimer.Start();//ΞΕΚΙΝΑΕΙ Η ΣΕΙΡΑ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
                    }
                    else if ((string)enemyPositionButtons[index].Tag == "enemy_upovrixio")//ΑΚΟΛΟΥΘΟΥΝ ΤΑ ΙΔΙΑ ΑΠΛΑ ΣΕ ΠΕΡΙΠΤΩΣΗ ΥΠΟΒΡΥΧΙΟΥ
                    {
                        enemyPositionButtons[index].Enabled = false;
                        enemyPositionButtons[index].BackgroundImage = Properties.Resources.X;
                        enemyPositionButtons[index].BackColor = Color.White;                       
                        enemyPositionButtons.RemoveAt(index);
                        EnemyLocationListBox.Items.RemoveAt(index);
                        enemy_upovrixio--;
                        playerScore += 1;
                        txtPlayer.Text = playerScore.ToString();

                        if (enemy_upovrixio == 0)
                        {
                            //MessageBox.Show("Μόλις Κατατράφηκε ένα ΥΠΟΒΡΥΧΙΟ", "Μπράβο!!");
                            Shipdestroyedmessages ship1 = new Shipdestroyedmessages();
                            ship1.print_result(2, "Μπράβο!!");
                        }

                        EnemyPlayTimer.Start();//ΞΕΚΙΝΑΕΙ Η ΣΕΙΡΑ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
                    }
                    else //ΑΝ ΔΕΝ ΒΡΟΥΜΕ ΠΛΟΙΟ
                    {
                        enemyPositionButtons[index].Enabled = false; //ΓΙΝΕΤΑΙ ΠΑΛΙ ΑΝΕΝΕΡΓΟ ΤΟ ΚΟΥΜΠΙ
                        enemyPositionButtons[index].BackgroundImage = Properties.Resources.space; //ΜΕ ΕΙΚΟΝΑ ΜΙΑ ΠΡΑΣΣΙΝΗ ΠΑΥΛΑ
                        enemyPositionButtons[index].BackColor = Color.White;                        
                        enemyPositionButtons.RemoveAt(index); //ΤΟ ΔΙΑΓΡΑΦΟΥΜΕ ΑΠΟ ΤΑ ΚΟΥΜΠΙΑ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
                        EnemyLocationListBox.Items.RemoveAt(index); //ΤΟ ΔΙΑΓΡΑΦΟΥΜΕ ΑΠΟ ΤΗΝ ΛΙΣΤΑ ΠΟΥ ΒΛΕΠΟΥΜΕ ΓΙΑ ΤΗΝ ΕΠΟΜΕΝΗ ΚΙΝΗΣΗ ΜΑΣ
                        EnemyPlayTimer.Start();//ΞΕΚΙΝΑΕΙ Η ΣΕΙΡΑ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
                    }
                }
            }
            else //ΑΝ ΔΕΝ ΔΩΣΟΥΜΕ ΣΗΜΕΙΟ ΕΜΦΑΝΙΖΕΤΑΙ ΜΗΝΥΜΑ
            {
                //MessageBox.Show("Επέλεξε Σημείο απο το Drop-Down", "Προσοχή!");
                Shipdestroyedmessages ship1 = new Shipdestroyedmessages();
                ship1.print_result(108, "Μπράβο!!");
            }

            if (round > 86 || enemyScore > 13 || playerScore > 13)  //ΕΛΕΓΧΟΣ ΝΙΚΩΝ Ή ΙΣΟΠΑΛΙΑΣ
            {
                EnemyPlayTimer.Stop();
                if (playerScore > enemyScore) //ΑΝ ΕΧΟΥΜΕ ΦΤΑΣΕΙ ΠΙΟ ΓΡΗΓΟΡΑ ΣΕ ΣΚΟΡ 13
                {
                    player_total_win++;  //ΑΥΞΑΝΟΥΜΕ ΤΗΝ ΜΕΤΑΒΛΗΤΗ ΣΥΝΟΛΙΚΩΝ ΝΙΚΩΝ ΚΑΤΑ 1
                    Entity1 c1 = new Entity1(); //ΜΕΤΑΒΛΗΤΗ ΓΙΑ ΝΑ ΚΑΤΑΧΩΡΗΣΟΥΜΕ ΤΑ ΣΤΑΤΙΣΤΙΚΑ ΣΕ ΒΑΣΗ ΔΕΔΟΜΕΝΩΝ
                    c1.Winners = "Player"; //ΚΑΤΑΧΩΡΗΣΗ ΣΤΟΝ ΠΙΝΑΚΑ ENTITY1, ΣΤΗΝ ΣΤΗΛΗ WINNERS ΤΟ ΟΝΟΜΑ ΤΟΥ ΝΙΚΗΤΗ
                    container.Entity1Set.Add(c1);
                   container.SaveChanges();
                   Messageprinter messageprinter = new Messageprinter();
                   int result = messageprinter.result_print_W(playerScore, enemyScore, round, player_total_win, enemy_total_win);
                   
                    if (result == 1)  //ΑΝ ΘΕΛΟΥΜΕ ΕΠΑΝΑΚΙΝΗΣΗ ΠΑΤΑΜΕ ΤΟ ΝΑΙ
                    {
                        RestartGame();
                    }
                    else
                    {
                        this.Dispose();
                    }

                }
                else if (enemyScore > playerScore)  //ΤΑ ΙΔΙΑ ΑΚΡΙΒΩΣ ΑΠΛΑ ΣΕ ΠΕΡΙΠΤΩΣΗ ΝΙΚΗΣ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
                {
                    enemy_total_win++;
                       Entity1 c1 = new Entity1();
                       c1.Winners = "Enemy";
                        container.Entity1Set.Add(c1);
                       container.SaveChanges();

                    Messageprinter messageprinter = new Messageprinter();
                    int result = messageprinter.result_print_L(playerScore, enemyScore, round, player_total_win, enemy_total_win);

                    if (result == 1)  //ΑΝ ΘΕΛΟΥΜΕ ΕΠΑΝΑΚΙΝΗΣΗ ΠΑΤΑΜΕ ΤΟ ΝΑΙ
                    {
                        RestartGame();
                    }
                    else
                    {
                        this.Dispose();

                    }
                } 
                else if (enemyScore == playerScore)   //ΤΑ ΙΔΙΑ ΑΠΛΑ ΣΕ ΠΕΡΙΠΤΩΣΗ ΙΣΟΠΑΛΙΑΣ
                {
                       Entity1 c1 = new Entity1();
                       c1.Winners = "Isopalia";
                       container.Entity1Set.Add(c1);
                      container.SaveChanges();

                    Messageprinter messageprinter = new Messageprinter();
                    int result = messageprinter.result_print_X(playerScore, enemyScore, round, player_total_win, enemy_total_win);

                    if (result == 1)  //ΑΝ ΘΕΛΟΥΜΕ ΕΠΑΝΑΚΙΝΗΣΗ ΠΑΤΑΜΕ ΤΟ ΝΑΙ
                    {
                        RestartGame();
                    }
                    else
                    {
                        this.Dispose();
                    }
                }
            }
        }
      
        //ΟΤΑΝ ΞΕΚΙΝΑΕΙ Η ΣΕΙΡΑ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
        private void EnemyPlayTimerEvent(object sender, EventArgs e)
        {
            if (playerPositionButtons.Count > 0 && round <= 86) //ΕΛΕΓΧΕΙ ΑΝ ΜΑΣ ΕΧΟΥΝ ΜΕΙΝΕΙ ΚΟΥΜΠΙΑ ΔΙΑΘΕΣΙΜΑ ΚΑΙ ΟΤΙ ΔΕΝ ΕΧΟΥΜΕ ΠΕΡΑΣΕΙ ΤΟ 86 ΓΥΡΟ
            {
                round += 1; //ΑΝΕΒΑΖΟΥΕ+1 ΤΟΝ ΓΥΡΟ
                txtRounds.Text = round.ToString();

                int index = rand.Next(playerPositionButtons.Count);  //ΕΠΙΛΕΓΕΙ ΕΝΑ ΤΥΧΑΙΟ ΚΟΥΜΠΙ ΓΙΑ ΕΠΙΘΕΣΗ ΑΠΟ ΤΑ ΔΙΚΑ ΜΑ Σ ΚΟΥΜΠΙΑ

                if ((string)playerPositionButtons[index].Tag == "player_aeroplanoforo") //ΑΝ ΕΧΕΙ TAG ΟΤΙ ΕΙΝΑΙ ΑΕΡΟΠΛΑΝΟΦΟΡΟ
                {
                    playerPositionButtons[index].BackgroundImage = Properties.Resources.X; //ΚΑΝΕΙ ΤΟ ΠΛΟΙΟ ΚΟΚΚΙΝΟ
                    enemyMove.Text = playerPositionButtons[index].Text; //ΓΡΑΦΕΙ ΣΤΟ ΚΟΥΤΑΚΙ ΠΟΥ ΔΕΙΧΝΕΙ ΤΗΝ ΚΙΝΗΣΗ ΤΟΥ ΑΝΤΙΠΑΛΟΥ ΤΟ ΣΗΜΕΙΟ ΕΠΙΘΕΣΗΣ
                    playerPositionButtons[index].Enabled = false;
                    playerPositionButtons[index].BackColor = Color.White;
                    playerPositionButtons.RemoveAt(index);  //ΔΙΑΓΡΑΦΕΙ ΤΟ ΚΟΥΜΠΙ ΑΠΟ ΤΟ ΛΙΣΤΑ ΚΟΥΜΠΙΩΝ ΓΙΑ ΝΑ ΜΗΝ ΞΑΝΑ ΧΤΥΠΗΣΕΙ ΣΤΟ ΙΔΙΟ ΣΗΜΕΙΟ
                    enemyScore += 1; //ΑΝΕΒΑΖΕΙ ΤΟ ΣΚΟΡ ΤΟΥ ΚΑΤΑ 1
                    player_aeroplanoforo--; //ΜΕΙΩΝΕΙ ΤΟ ΔΙΚΑ ΜΑΣ ΑΕΡΟΠΛΑΝΟΦΟΡΑ ΚΑΤΑ 1
                    txtEnemy.Text = enemyScore.ToString();

                    if (player_aeroplanoforo == 0) //ΑΝ ΒΡΕΙ ΟΛΑ ΤΑ ΑΕΡΟΠΛΑΝΟΦΟΡΑ
                    {

                       // MessageBox.Show("Μόλις Κατατράφηκε ένα ΥΠΟΒΡΥΧΙΟ", "Δυστυχώς!!");
                        Shipdestroyedmessages ship1 = new Shipdestroyedmessages();
                        ship1.print_result(5, "Δυστυχώς!!");
                    }

                    EnemyPlayTimer.Stop();//ΤΕΛΕΙΩΝΕΙ Η ΕΠΙΘΕΣΗ ΤΟΥ ΑΝΤΙΠΑΛΟΥ
                }
                else if ((string)playerPositionButtons[index].Tag == "player_antirtopoiliko")  //ΑΚΟΛΟΥΘΟΥΝ ΤΑ ΙΔΙΑ ΓΙΑ ΤΟ ΠΛΟΙΟ ΑΝΤΙΡΤΟΠΟΙΛΙΚΟ
                {
                    playerPositionButtons[index].BackgroundImage = Properties.Resources.X;
                    enemyMove.Text = playerPositionButtons[index].Text;
                    playerPositionButtons[index].Enabled = false;
                    playerPositionButtons[index].BackColor = Color.White;
                    playerPositionButtons.RemoveAt(index);
                    //playerPositionButtons[index].Text = null;
                    enemyScore += 1;
                    player_antirtopiliko--;
                    txtEnemy.Text = enemyScore.ToString();
                    if (player_antirtopiliko == 0)
                    {
                        //MessageBox.Show("Μόλις Κατατράφηκε ένα ΑΝΤΙΡΤΟΠΟΙΛΙΚΟ", "Δυστυχώς!!");
                        Shipdestroyedmessages ship1 = new Shipdestroyedmessages();
                        ship1.print_result(4, "Δυστυχώς!!");
                    }

                    EnemyPlayTimer.Stop();
                }
                else if ((string)playerPositionButtons[index].Tag == "player_polemiko")//ΑΚΟΛΟΥΘΟΥΝ ΤΑ ΙΔΙΑ ΓΙΑ ΤΟ ΠΛΟΙΟ ΠΟΛΕΜΙΚΟ
                {
                    playerPositionButtons[index].BackgroundImage = Properties.Resources.X;
                    enemyMove.Text = playerPositionButtons[index].Text;
                    playerPositionButtons[index].Enabled = false;
                    playerPositionButtons[index].BackColor = Color.White;
                    playerPositionButtons.RemoveAt(index);
                    //playerPositionButtons[index].Text = null;
                    enemyScore += 1;
                    player_polemiko--;
                    if (player_polemiko == 0)
                    {
                        //MessageBox.Show("Μόλις Κατατράφηκε ένα ΠΟΛΕΜΙΚΟ", "Δυστυχώς!!");
                        Shipdestroyedmessages ship1 = new Shipdestroyedmessages();
                        ship1.print_result(3, "Δυστυχώς!!");
                    }
                    txtEnemy.Text = enemyScore.ToString();

                    EnemyPlayTimer.Stop();
                }
                else if ((string)playerPositionButtons[index].Tag == "player_upovrixio")
                {
                    playerPositionButtons[index].BackgroundImage = Properties.Resources.X;
                    enemyMove.Text = playerPositionButtons[index].Text;
                    playerPositionButtons[index].Enabled = false;
                    playerPositionButtons[index].BackColor = Color.White;
                    playerPositionButtons.RemoveAt(index);
                    //playerPositionButtons[index].Text = null;
                    enemyScore += 1;
                    player_upovrixio--;
                    txtEnemy.Text = enemyScore.ToString();
                    if (player_upovrixio == 0)
                    {

                        // MessageBox.Show("Μόλις Κατατράφηκε ένα ΥΠΟΒΡΥΧΙΟ", "Δυστυχώς!!");
                        Shipdestroyedmessages ship1 = new Shipdestroyedmessages();
                        ship1.print_result(2, "Δυστυχώς!!");
                    }
                    EnemyPlayTimer.Stop();
                }
                else //ΑΝ ΔΕΝ ΒΡΕΙ ΠΛΟΙΟ
                {
                    playerPositionButtons[index].BackgroundImage = Properties.Resources.space; //ΜΠΑΙΝΕΙ ΣΑΝ ΕΙΚΟΝΑ ΣΤΟ ΚΟΥΜΠΙ ΜΙΑ ΠΡΑΣΣΙΝΗ ΠΑΥΛΑ
                    enemyMove.Text = playerPositionButtons[index].Text;
                    playerPositionButtons[index].Enabled = false;
                    playerPositionButtons[index].BackColor = Color.White;
                    playerPositionButtons.RemoveAt(index);
                    EnemyPlayTimer.Stop();
                }
            }

            if (round > 86 || enemyScore > 13 || playerScore > 13) //ΕΛΕΓΧΟΣ ΝΙΚΩΝ ΤΟ ΙΔΙΟ ΜΕ ΤΟΝ ΠΙΟ ΠΑΝΩ ΕΛΕΓΧΟ ΣΤΗΝ ΠΡΟΗΓΟΥΜΕΝΗ ΣΥΝΑΡΤΗΣΗ
            {
                EnemyPlayTimer.Stop();
                if (playerScore > enemyScore)
                {
                    player_total_win++;

                     Entity1 c1 = new Entity1();
                     c1.Winners = "Player";
                     container.Entity1Set.Add(c1);
                     container.SaveChanges();
                    Messageprinter messageprinter = new Messageprinter();
                    int result = messageprinter.result_print_W(playerScore, enemyScore, round, player_total_win, enemy_total_win);

                    if (result == 1)  //ΑΝ ΘΕΛΟΥΜΕ ΕΠΑΝΑΚΙΝΗΣΗ ΠΑΤΑΜΕ ΤΟ ΝΑΙ
                    {
                        RestartGame();
                    }
                    else
                    {
                        this.Dispose();

                    }

                }
                else if (enemyScore > playerScore)
                {
                    enemy_total_win++;


                       Entity1 c1 = new Entity1();
                       c1.Winners = "Enemy";
                      container.Entity1Set.Add(c1);
                      container.SaveChanges();
                    Messageprinter messageprinter = new Messageprinter();
                    int result = messageprinter.result_print_L(playerScore, enemyScore, round, player_total_win, enemy_total_win);

                    if (result == 1)  //ΑΝ ΘΕΛΟΥΜΕ ΕΠΑΝΑΚΙΝΗΣΗ ΠΑΤΑΜΕ ΤΟ ΝΑΙ
                    {
                        RestartGame();
                    }
                    else
                    {
                        this.Dispose();

                    }
                }
                else if (enemyScore == playerScore)
                {

                      Entity1 c1 = new Entity1();
                       c1.Winners = "Isopalia";
                     container.Entity1Set.Add(c1);
                     container.SaveChanges();
                    Messageprinter messageprinter = new Messageprinter();
                    int result = messageprinter.result_print_W(playerScore, enemyScore, round, player_total_win, enemy_total_win);

                    if (result == 1)  //ΑΝ ΘΕΛΟΥΜΕ ΕΠΑΝΑΚΙΝΗΣΗ ΠΑΤΑΜΕ ΤΟ ΝΑΙ
                    {
                        RestartGame();
                    }
                    else
                    {
                        this.Dispose();

                    }
                }
            }
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
         
        }
        public void resizeChildernControls()
        {
    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
        }
      
        public void resizeControl(Rectangle originalControlRect, Control control, float originalFontSize)
        {
  
        }
    }
}