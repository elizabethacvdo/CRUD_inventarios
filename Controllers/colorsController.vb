Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports mery_asp

Namespace Controllers
    Public Class colorsController
        Inherits System.Web.Mvc.Controller

        Private db As New inventarioEntities

        ' GET: colors
        Function Index() As ActionResult
            Return View(db.colors.ToList())
        End Function

        ' GET: colors/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim color As color = db.colors.Find(id)
            If IsNothing(color) Then
                Return HttpNotFound()
            End If
            Return View(color)
        End Function

        ' GET: colors/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: colors/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id_color,color1,estado")> ByVal color As color) As ActionResult
            If ModelState.IsValid Then
                db.colors.Add(color)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(color)
        End Function

        ' GET: colors/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim color As color = db.colors.Find(id)
            If IsNothing(color) Then
                Return HttpNotFound()
            End If
            Return View(color)
        End Function

        ' POST: colors/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id_color,color1,estado")> ByVal color As color) As ActionResult
            If ModelState.IsValid Then
                db.Entry(color).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(color)
        End Function

        ' GET: colors/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim color As color = db.colors.Find(id)
            If IsNothing(color) Then
                Return HttpNotFound()
            End If
            Return View(color)
        End Function

        ' POST: colors/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim color As color = db.colors.Find(id)
            db.colors.Remove(color)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
