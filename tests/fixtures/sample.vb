Imports System
Imports System.Collections.Generic

Namespace Demo.App

    Public Interface IWorker
        Sub Run()
    End Interface

    Public Class BaseWorker
        Public Overridable Sub Log(message As String)
            Console.WriteLine(message)
        End Sub
    End Class

    Public Class Worker
        Inherits BaseWorker
        Implements IWorker

        Public Event Completed()

        Public Property Name As String

        Public Sub New(name As String)
            Me.Name = name
        End Sub

        Public Overrides Sub Log(message As String)
            Console.WriteLine("Worker: " & message)
        End Sub

        Public Sub Run() Implements IWorker.Run
            Log("running " & Name)
            RaiseEvent Completed()
        End Sub
    End Class

    Public Module Bootstrap
        Public Sub Main()
            Dim w As New Worker("demo")
            w.Run()
        End Sub
    End Module

End Namespace
