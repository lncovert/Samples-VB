﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
Imports System.Text

Namespace Samples.Application
    ''' <summary>
    ''' Reports all Solid Edge global parameters.
    ''' </summary>
    Friend Class ReportGlobalParameters
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            If StartupHelper.ShouldBreak() Then
                System.Diagnostics.Debugger.Break()
            End If

            Dim application As SolidEdgeFramework.Application = Nothing

            Try
                ' Register with OLE to handle concurrency issues on the current thread.
                SolidEdgeCommunity.OleMessageFilter.Register()

                ' Connect to or start Solid Edge.
                application = SolidEdgeCommunity.SolidEdgeUtils.Connect(True, True)

                ' Get the ApplicationGlobalConstants type.
                Dim type As Type = GetType(SolidEdgeFramework.ApplicationGlobalConstants)

                ' Get the fields of the type.
                Dim fields() As FieldInfo = type.GetFields()

                ' Enumerate the fields.
                For Each field As FieldInfo In fields
                    If field.IsSpecialName Then
                        Continue For
                    End If

                    ' Cast the raw constant value as ApplicationGlobalConstants.
                    Dim globalConstant As SolidEdgeFramework.ApplicationGlobalConstants = DirectCast(field.GetRawConstantValue(), SolidEdgeFramework.ApplicationGlobalConstants)
                    Dim val As Object = Nothing

                    Try
                        ' GetGlobalParameter() may throw an exception.
                        application.GetGlobalParameter(globalConstant, val)
                    Catch
                    End Try

                    Console.WriteLine("{0} = '{1}'", field.Name, val)
                Next field
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            Finally
                SolidEdgeCommunity.OleMessageFilter.Unregister()
            End Try
        End Sub
    End Class
End Namespace
