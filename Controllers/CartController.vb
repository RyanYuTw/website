Imports System.Web.Mvc
Imports Newtonsoft.Json
Imports My.Models

Namespace My.Controllers
    Public Class CartController
        Inherits Controller

        Private Const CartSessionKey As String = "ShoppingCart"

        Private Function GetCart() As CartViewModel
            Dim cart = TryCast(Session(CartSessionKey), CartViewModel)
            If cart Is Nothing Then
                cart = New CartViewModel With {.Items = New List(Of CartItem)()}
                Session(CartSessionKey) = cart
            End If
            Return cart
        End Function

        ' GET: /Cart
        Function Index() As ActionResult
            Return View(GetCart())
        End Function

        ' POST: /Cart/Add
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function Add(productId As Integer, qty As Integer) As ActionResult
            ' TODO: 查詢商品資訊
            Dim cart = GetCart()
            Dim existing = cart.Items.FirstOrDefault(Function(x) x.ProductId = productId)
            If existing IsNot Nothing Then
                existing.Quantity += qty
            Else
                ' cart.Items.Add(New CartItem With { ... })
            End If
            Session(CartSessionKey) = cart
            Return Json(New With {.success = True, .totalQty = cart.TotalQty})
        End Function

        ' POST: /Cart/Update
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function Update(productId As Integer, qty As Integer) As ActionResult
            Dim cart = GetCart()
            Dim item = cart.Items.FirstOrDefault(Function(x) x.ProductId = productId)
            If item IsNot Nothing Then
                If qty <= 0 Then
                    cart.Items.Remove(item)
                Else
                    item.Quantity = qty
                End If
            End If
            Session(CartSessionKey) = cart
            Return RedirectToAction("Index")
        End Function

        ' POST: /Cart/Remove
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function Remove(productId As Integer) As ActionResult
            Dim cart = GetCart()
            cart.Items.RemoveAll(Function(x) x.ProductId = productId)
            Session(CartSessionKey) = cart
            Return RedirectToAction("Index")
        End Function

        ' GET: /Cart/Checkout
        <Authorize>
        Function Checkout() As ActionResult
            Dim cart = GetCart()
            If cart.TotalQty = 0 Then Return RedirectToAction("Index")
            Dim vm = New CheckoutViewModel With {.Cart = cart}
            Return View(vm)
        End Function

        ' POST: /Cart/Checkout
        <HttpPost>
        <Authorize>
        <ValidateAntiForgeryToken>
        Function Checkout(model As CheckoutViewModel) As ActionResult
            If Not ModelState.IsValid Then
                model.Cart = GetCart()
                Return View(model)
            End If
            ' TODO: 建立訂單、清空購物車
            Session.Remove(CartSessionKey)
            Return RedirectToAction("Complete")
        End Function

        ' GET: /Cart/Complete
        Function Complete() As ActionResult
            Return View()
        End Function

    End Class
End Namespace
