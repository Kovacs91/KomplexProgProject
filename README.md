# Állatfajok

## Program terv
Ez a project egy iskolai dolog miatt készül. Ez a program egy grafikus szövegszerkesztő

## Felhasznált technológiák
- WPF
- C#


## Telepítés
A program használatához Windows operációs rendszer szükséges

## Érdekesebb megoldások
``` C#
	MessageBoxResult valasz = MessageBox.Show("Biztos kilépsz?", "Üzenet", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (valasz==MessageBoxResult.Yes)
            {
                this.Close();
            }
```
