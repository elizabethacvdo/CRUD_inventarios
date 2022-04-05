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
    Public Class categoriasController
        Inherits System.Web.Mvc.Controller

        Private db As New inventarioEntities

        ' GET: categorias
        Function Index() As ActionResult
            Return View(db.categorias.ToList())
        End Function

        ' GET: categorias/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim categoria As categoria = db.categorias.Find(id)
            If IsNothing(categoria) Then
                Return HttpNotFound()
            End If
            Return View(categoria)
        End Function

        ' GET: categorias/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: categorias/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id_categoria,categoria1,estado")> ByVal categoria As categoria) As ActionResult
            If ModelState.IsValid Then
                db.categorias.Add(categoria)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(categoria)
        End Function

        ' GET: categorias/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim categoria As categoria = db.categorias.Find(id)
            If IsNothing(categoria) Then
                Return HttpNotFound()
            End If
            Return View(categoria)
        End Function

        ' POST: categorias/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id_categoria,categoria1,estado")> ByVal categoria As categoria) As ActionResult
            If ModelState.IsValid Then
                db.Entry(categoria).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(categoria)
        End Function

        ' GET: categorias/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim categoria As categoria = db.categorias.Find(id)
            If IsNothing(categoria) Then
                Return HttpNotFound()
            End If
            Return View(categoria)
        End Function

        ' POST: categorias/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim categoria As categoria = db.categorias.Find(id)
            db.categorias.Remove(categoria)
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
