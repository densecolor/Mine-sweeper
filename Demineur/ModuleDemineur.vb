Module Module1

    Public Jeu(,) As Integer
    Private Decouvert(,) As Boolean
    Private Marque(,) As Boolean

    Private Sub PlacerMines(ByVal t As Integer, ByVal NbMines As Integer)
        Dim i As Integer, lig As Integer, col As Integer
        Dim mineplacee As Boolean
        Randomize()
        For i = 1 To NbMines 'je dois placer NbMines mines
            Do
                lig = CInt(Int(t * Rnd() + 1))
                col = CInt(Int(t * Rnd() + 1))
                mineplacee = Jeu(lig, col) <> -1
            Loop Until mineplacee
            Jeu(lig, col) = -1
        Next i
    End Sub

    'je initialise le jeu en placant les mines(-1) dans les cases, 
    'et les nombres(>=0) dans les cases, ces nombres representent le nombre de mines autour d'une case
    'et je mets les 2 tableaux egalent false, c'est a dire que tous les cases ne sont pas cliqués
    Public Sub Initialise(ByVal taille As Integer, ByVal nbmines As Integer)
        Dim i As Integer, j As Integer
        ReDim Jeu(taille, taille)
        ReDim Decouvert(taille, taille)
        ReDim Marque(taille, taille)

        PlacerMines(taille, nbmines)

        Jeu(i, j) = NombreMine(i, j, taille)

        For i = 1 To taille
            For j = 1 To taille
                Decouvert(i, j) = False
                Marque(i, j) = False
            Next
        Next
    End Sub


    'j'inventes un indicateur pour indiquer 3 situations,
    'si EstMarque()est true,la fonction retourne -2, c'est à dire que la case a été marquée ou démarquée
    'si EstMarque()est false, la fonction retourne -1 pourdire que la case découverte contenait une mine 
    'si EstMarque()est false, la fonction retourne -0 pourdire que la case découverte ne contenait pas de mine

    Public Function Jouer(ByVal i As Integer, ByVal j As Integer) As Integer
        Dim indicateur As Integer

        If EstMarque(i, j) Then
            indicateur = -2
        ElseIf Jeu(i, j) = -1 Then
            indicateur = -1
        Else
            indicateur = 0
        End If
        Return indicateur
    End Function

    'quelles sont les cases découvertes à l'issue du coup joué 
    Public Function EstDecouvert(ByVal i As Integer, ByVal j As Integer) As Boolean
        Dim d As Boolean

        If Decouvert(i, j) Then
            d = True
        Else
            d = False
        End If
        Return d

    End Function
    'quelles sont les cases marquées
    Public Function EstMarque(ByVal i As Integer, ByVal j As Integer) As Boolean
        Dim m As Boolean

        If Marque(i, j) Then
            m = True
        Else
            m = False
        End If
        Return m
    End Function


    'cette fonction retourne le nombre de mines adjacentes d'une case
    'il faut être sûr que les cases à juger sont inférieures à la bordure 
    Public Function NombreMine(ByVal i As Integer, ByVal j As Integer, ByVal taille As Integer) As Integer
        Dim nb As Integer

        For i = 1 To taille
            For j = 1 To taille


                If Jeu(i, j) <> -1 Then
                    nb = 0
                    For r = -1 To 1
                        For c = -1 To 1

                            Dim blnDx As Boolean
                            Dim blnDy As Boolean

                            blnDy = j + r >= 0 And j + r <= taille
                            blnDx = i + c >= 0 And i + c <= taille

                            If blnDy And blnDx Then  'pour être sûr que les cases à juger sont inférieures à la bordure  
                                If Jeu(i + c, j + r) = -1 Then ' si jeu()=-1, il y a une mine dans la case adjacente, le nombre plus 1
                                    nb = nb + 1
                                End If
                            End If
                        Next
                    Next
                    Jeu(i, j) = nb
                End If

            Next
        Next
        Return nb
    End Function

    'je mets cette fonction dans clickJeu MouseButtons.Right, 
    'chaque fois je clique droit sur le souris, l'état de la case change, 
    'c'est à dire que la valeur du tableau marque() change
    Public Sub ChangeMarque(ByVal lig As Integer, ByVal col As Integer)

        If EstMarque(lig, col) Then
            Marque(lig, col) = False
        Else
            Marque(lig, col) = True
        End If

    End Sub

    'cette procédure est pour traiter la situation lorsque le nombre dans une case égale à 0
    'je propage les cases en utilisant une méthode de récurrence, c'est-à-dire dans cette procédure je rappelle la procédure elle-même 
    'pour propager les cases adjacentes de même façon que la case initiale, jusqu'au où les cases sont marquées ou découvertes
    Public Sub TraiteZero(ByVal i As Integer, ByVal j As Integer, ByVal taille As Integer)
        'avant de commencer, il faut que la case elle-même est découverte 
        Decouvert(i, j) = True
        If Jeu(i, j) = 0 Then
            For r = -1 To 1
                For c = -1 To 1
                    Dim blnDx As Boolean
                    Dim blnDy As Boolean

                    blnDy = j + r >= 1 And j + r <= taille
                    blnDx = i + c >= 1 And i + c <= taille

                    If blnDy And blnDx Then
                        If EstDecouvert(i + c, j + r) = False And EstMarque(i + c, j + r) = False Then
                            TraiteZero(i + c, j + r, taille) 'je rappelle la procédure elle-même
                        End If
                    End If
                Next
            Next
        End If

    End Sub

    'je calcule le nombre de mines reste lorsque je clique à droit pour placer ou enlever un drapeau
    Public Function NbMinesReste(ByVal taille As Integer, ByVal nbMines As Integer) As Integer
        Dim NbReste As Integer

        NbReste = 0
        For i = 1 To taille
            For j = 1 To taille
                If EstMarque(i, j) Then
                    NbReste = NbReste + 1
                End If
            Next
        Next
        NbReste = nbMines - NbReste
        Return NbReste
    End Function

    'je calcule le nombre de mines decouvertes lorsque je clique à gauche
    Public Function NbMineDecouvert(ByVal taille As Integer, ByVal nbMines As Integer)

        Dim Nbdecouvert As Integer
        Nbdecouvert = 0
        For i = 1 To taille
            For j = 1 To taille
                If EstDecouvert(i, j) And Jeu(i, j) <> -1 Then
                    Nbdecouvert = Nbdecouvert + 1
                End If
            Next
        Next

        Return Nbdecouvert
    End Function

End Module

