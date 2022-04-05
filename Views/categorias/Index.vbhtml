@ModelType IEnumerable(Of mery_asp.categoria)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.categoria1)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.estado)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.categoria1)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.estado)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.id_categoria }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.id_categoria }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.id_categoria })
        </td>
    </tr>
Next

</table>
