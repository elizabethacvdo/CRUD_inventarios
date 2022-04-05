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
    Public Class productoesController
        Inherits System.Web.Mvc.Controller

        Private db As New productosEntities

        ' GET: productoes
        Function Index() As ActionResult
            Return View(db.productoes.ToList())
        End Function

        ' GET: productoes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim producto As producto = db.productoes.Find(id)
            If IsNothing(producto) Then
                Return HttpNotFound()
            End If
            Return View(producto)
        End Function

        ' GET: productoes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: productoes/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,categoriaid,producto1,precio,estado")> ByVal producto As producto) As ActionResult
            If ModelState.IsValid Then
                db.productoes.Add(producto)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(producto)
        End Function

        ' GET: productoes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim producto As producto = db.productoes.Find(id)
            If IsNothing(producto) Then
                Return HttpNotFound()
            End If
            Return View(producto)
        End Function

        ' POST: productoes/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,categoriaid,producto1,precio,estado")> ByVal producto As producto) As ActionResult
            If ModelState.IsValid Then
                db.Entry(producto).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(producto)
        End Function

        ' GET: productoes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim producto As producto = db.productoes.Find(id)
            If IsNothing(producto) Then
                Return HttpNotFound()
            End If
            Return View(producto)
        End Function

        ' POST: productoes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim producto As producto = db.productoes.Find(id)
            db.productoes.Remove(producto)
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
