Imports System
Imports System.Collections.Generic

Namespace Demo.Domain

Public Interface IEtape
    Function Compute(ByVal x As Integer) As Double
End Interface

Public Class Etape
    Public Property Numero As Integer

    Public Function Base(ByVal x As Integer) As Double
        Return x * 2
    End Function
End Class

Public Class EtapeElaboration
    Inherits Etape
    Implements IEtape

    Public Sub New()
        MyBase.New()
    End Sub

    ' FCT_MALOInitial calls two sibling methods and instantiates a same-file type.
    Public Function FCT_MALOInitial(ByVal x As Integer) As Double
        Dim r As New Recherche(x)
        FCT_AdaptORMAL(x)
        Return FCT_RecupMalParDefaut(x)
    End Function

    Private Sub FCT_AdaptORMAL(ByVal y As Integer)
        ' Member call into another file's type -> deferred to raw_calls.
        Helper.DoExternalThing(y)
    End Sub

    Public Function FCT_RecupMalParDefaut(ByVal z As Integer) As Double
        Return Base(z)
    End Function

    Public Function Compute(ByVal x As Integer) As Double Implements IEtape.Compute
        Return FCT_MALOInitial(x)
    End Function
End Class

' Single inheritance chain entirely within this file.
Public Class Soufflage
    Inherits EtapeElaboration
End Class

Public Class Recherche
    Public Sub New(ByVal seed As Integer)
    End Sub

    Public Sub Go()
    End Sub
End Class

End Namespace
