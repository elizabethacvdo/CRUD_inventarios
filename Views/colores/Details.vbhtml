@ModelType mery_asp.colore
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>colore</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.color)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.color)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.estado)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.estado)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.colores }) |
    @Html.ActionLink("Back to List", "Index")
</p>
