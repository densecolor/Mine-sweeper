Public Class FormDemineur
    Dim s As Integer
    Public taille As Integer
    Public NbMines As Integer
    Public table(taille, taille) As Button
    'declarer l'array du couleur de case
    Public casecolor = New Color() {Color.White,
                                    Color.LightSkyBlue,
                                    Color.LightGreen,
                                    Color.LightPink,
                                    Color.Orange,
                                    Color.Red,
                                    Color.Cyan,
                                    Color.Brown,
                                    Color.Ivory}


    Private Sub FormDemineur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InterLook(1)
        recharger()
        Lblnbrr.Text = NbMines
    End Sub


    Private Sub Affiche(ByVal i As Integer, ByVal j As Integer, ByVal indicateur As Integer)
        Dim NbMinesRest As Integer
        Dim NbDecouvert As Integer


        Lblnbrr.Text = NbMines
        NbMinesRest = NbMinesReste(taille, NbMines)
        NbDecouvert = NbMineDecouvert(taille, NbMines)

        'la première situation , l'indicateur égale à -2
        If indicateur = -2 Then
            'si la case a été marqué, je mets une image d'un drapeau dans cette case 
            If EstMarque(i, j) Then
                'table(i, j).text = "p"
                table(i, j).Image = My.Resources.qi
                'si la case a été démarqué, je mets rien dans cette case 
            Else
                'table(i, j).Text = ""
                table(i, j).Image = Nothing
            End If
            Lblnbrr.Text = NbMinesRest
        End If



        'la deuxième  situation , l'indicateur égale à -1
        If indicateur = -1 Then
            'je clique sur une case contient mine, j'ai perdu, l'image du boutton restart devine pleurer
            Lblnbrr.Text = "0"
            MsgBox("perdu")
            btnrestart.Image = My.Resources.ku

            For i = 1 To taille
                For j = 1 To taille
                    If Jeu(i, j) = -1 Then
                        'je mets une image d'une mine dans cette case 
                        If table(i, j).Image Is Nothing Then
                            table(i, j).Image = My.Resources.lei
                            table(i, j).Enabled = True
                        End If
                        'si cette case ne contient pas de mine(jeu()n'égale pas à-1), mais j'ai déjà mets un drapeau dans cette case
                        'c'est à dire que j'ai mal placé le drapeau, l'image de cette case devine une image qui indique que j'ai torte
                    ElseIf table(i, j).Image IsNot Nothing Then
                        table(i, j).Image = My.Resources.wrong
                    End If
                    Timer1.Enabled = False
                    'si le jeu est fini et j'ai perdu, je donne la valeur -3 aux cases restes(estdecouverte est false)
                    'pour ces cases, même elles ne sont pas découvertes
                    'lorsque je cliquer sur elles, elles ne changent pas. voir la procédure affiche()
                    If table(i, j).Enabled = True Then
                        Jeu(i, j) = -3
                    End If
                Next
            Next
        End If


        'la troisième  situation , l'indicateur égale à 0
        If indicateur = 0 Then
            Lblnbrr.Text = NbMinesRest
            'la case elle-même est 0, c'est-à-dire que pas de mine dans les case adjacentes d'elle
            If Jeu(i, j) = 0 Then
                For i = 1 To taille
                    For j = 1 To taille
                        If EstDecouvert(i, j) Then
                            table(i, j).BackColor = casecolor(Jeu(i, j))
                            table(i, j).Enabled = False
                            ' il faut juger dans les cases déjà découvertes, c'est 0 ou non, si c'est 0, le nombre 0 n'affiche pas
                            If Jeu(i, j) = 0 Then
                                table(i, j).Text = ""
                            Else
                                'si c'est pas 0, le nombre s'affiche
                                table(i, j).Text = Jeu(i, j)
                            End If
                        Else
                            table(i, j).Enabled = True
                        End If
                    Next
                Next
            Else
                'la case elle-même est supérieur à 0, je désactive la case et affiche le nombre dedans
                table(i, j).Text = Jeu(i, j)
                table(i, j).Enabled = False
                table(i, j).BackColor = casecolor(Jeu(i, j))
            End If
        End If

        'on va parcourir le tableau, si toutes les cases ne contiennent pas des mines sont déjà découvertes, on gagne
        'si je gagne, j'affiche tous les mines, je donne la valeur -3 à ces cases de mine
        'pour ces cases de mine ne découvertes 
        'lorsque je cliquer sur elles, elles ne changent pas. voir la procédure affiche()

        If taille * taille - NbDecouvert = NbMines Then
            MsgBox("gagner")
            btnrestart.Image = My.Resources.xiao

            For i = 1 To taille
                For j = 1 To taille

                    If Jeu(i, j) = -1 Then
                        table(i, j).Image = My.Resources.lei
                    End If

                    If table(i, j).Enabled = True Then
                        Jeu(i, j) = -3 '判断游戏胜利后，给剩下的雷的格子赋值-3，使其不可点击，见后面affiche函数

                    End If
                Next
            Next
        End If
    End Sub

    Private Sub clickJeu(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim cj As Integer, lig As Integer, col As Integer
        'interception d'un click sur une des cases du jeu
        'calcul de la ligne et de la colonne correspondant à la case jouée
        cj = sender.tag 'indice

        lig = Ligne(cj, taille) 'quel ligne
        col = Colonne(cj, taille) 'quel colonne
        If lig = 0 Then
            lig = taille
            col = cj / taille
        End If
        'le bouton cliqué devient inactif
        sender.enabled = False
        'on détermine si c'est un click droit ou un click gauche qui a été fait en testant e.Button
        Select Case e.Button '
            Case Windows.Forms.MouseButtons.Right 'click droit traite la première situation(indicateur -2)
                If Jeu(lig, col) > -3 Then
                    Timer1.Enabled = True
                    table(lig, col).Enabled = True
                    ChangeMarque(lig, col)

                    Affiche(lig, col, -2)
                Else
                    table(lig, col).Enabled = True ' les cases sont activées, mais pas de changement
                End If


            Case Windows.Forms.MouseButtons.Left 'click gauche traite la deuxième et la troisième situation(indicateur -1 et 0)

                If Jeu(lig, col) > -3 And Not EstMarque(lig, col) Then

                    Timer1.Enabled = True
                    TraiteZero(lig, col, taille)
                    Affiche(lig, col, Jouer(lig, col))

                Else
                    table(lig, col).Enabled = True ' les cases sont activées, mais pas de changement
                End If
        End Select
    End Sub

    Private Function Ligne(ByVal cj As Integer, ByVal t As Integer) As Integer

        Return cj Mod t
    End Function

    Private Function Colonne(ByVal cj As Integer, ByVal t As Integer) As Integer

        Return Int(cj / t) + 1
    End Function

    Private Sub restart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrestart.Click
        recharger()
    End Sub
    Private Sub recharger()
        Initialise(taille, NbMines) 'initialiser le jeu
        btnrestart.Image = My.Resources.xiao 'initialise l'image de rejouer a sourire
        Lblnbrr.Text = NbMines 'initialiser le nombre de mines
        Timer1.Enabled = False 'initialiser le temps
        s = -1 'initialiser le temps
        'initialiser les cases
        For i = 1 To taille
            For j = 1 To taille
                table(i, j).BackColor = Color.LightGray
                table(i, j).Text = ""
                table(i, j).Image = Nothing
                table(i, j).Enabled = True
            Next
        Next
    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        's représente la seconde
        s = s + 1
        lbls.Text = s
    End Sub

    ' clique sur bouton dans la menu qui représente les 4 niveaux du jeu
    Private Sub BeginnerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeginnerToolStripMenuItem.Click
        InterLook(1)
        recharger()
    End Sub

    Private Sub IntermediateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntermediateToolStripMenuItem.Click

        InterLook(2)
        recharger()
    End Sub

    Private Sub ExpertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpertToolStripMenuItem.Click

        InterLook(3)
        recharger()
    End Sub

    Private Sub PersonalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonalToolStripMenuItem.Click

        InterLook(0)
        recharger()
    End Sub

    Public Sub InterLook(ByVal range As Integer)
        Dim a, b As String
        'juger les niveaux du jeu 
        Select Case range
            Case 1
                taille = 9
                nbmines = 10
            Case 2
                taille = 16
                nbmines = 40
            Case 3
                taille = 30
                nbmines = 100
            Case 0

                a = InputBox("Saisit la taille(un nombre entre 5 et 30) SVP")
                b = InputBox("Saisit le nombre de mines(un nombre entre 1 et 100)SVP")
                If String.IsNullOrEmpty(a) Or String.IsNullOrEmpty(b) Then

                ElseIf CInt(b) >= CInt(a) * CInt(a) Then
                    MsgBox("Le nombre de mines doit etre inferieur a le nombre de case")
                Else
                    taille = CInt(a)
                    NbMines = CInt(b)
                End If
        End Select

        Dim i, lig, col As Integer
        Dim cb As Button

        ReDim table(taille, taille) 'redim le tableau de cases, très important 
        If taille >= 9 Then
            pnlJeu.Width = 30 * taille + 5 : pnlJeu.Height = 30 * taille + 5
            Width = 30 * taille + 70 : Height = 30 * taille + 150
        Else
            pnlJeu.Width = 30 * taille + 5 : pnlJeu.Height = 30 * taille + 5
            Width = 30 * 9 + 70 : Height = 30 * 9 + 150
        End If
        pnlJeu.Controls.Clear() 'supprimer tous les cases(boutons) anciennes
        'sinon seule les cases non découvertes vont être récrées(remplacées)
        col = 1 : lig = 0
        For i = 1 To taille * taille
            cb = New Button
            cb.Width = 30 : cb.Height = 30 : cb.Text = ""
            cb.Tag = i  'permet de savoir le numéro du bouton qui sera cliqué
            lig = lig + 1
            cb.Top = 4 + (lig - 1) * cb.Height
            cb.Left = 4 + (col - 1) * cb.Width

            table(lig, col) = cb
            pnlJeu.Controls.Add(cb)
            AddHandler cb.MouseDown, AddressOf clickJeu
            If i Mod taille = 0 Then
                lig = 0 : col = col + 1
            End If
        Next
        'on initialise le Jeu
        Call Initialise(taille, NbMines)

    End Sub

End Class
