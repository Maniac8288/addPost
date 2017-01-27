# addPost
@using eShop.Models;
@model IEnumerable<ProductModel>

@{
    ViewBag.Title = "Управление";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Управление товарами</h2>
<hr />

<div class="row">
    <p><a class="btn btn-default" href="/Home/AddProduct">Добавить товар</a></p>
    <table class="table table-hover table-striped">
        <thead>
            <tr>
                <th></th>
                <th></th>
                <th></th>
                <th>#</th>
                <th>Название</th>
                <th>Категория</th>
                <th>Цена</th>
                <th>Дата добавления</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var item in Model)
            {
                <tr id="productRow">
                    <td><a class="btn btn-link" href="@Url.Action("Edit","Home",new { id = item.productId })">Редактировать</a></td>
                    <td><a class="btn btn-link" href="@Url.Action("Details","Home",new { id = item.productId })">Просмотр</a></td>
                    <td><a class="btn btn-link" href="@Url.Action("DeleteProduct", "Home", new { id = item.productId })" data-toggle="confirmation" >Удалить</a></td>
                    <td>@item.productId</td>
                    <td>@item.productName</td>
                    <td>@item.selectedCategory</td>
                    <td>@item.productPrice</td>
                    <td>@item.dateAdd</td>
                </tr>
            }
        </tbody>
    </table>
</div>
@* onclick="JavaScript:return confirm('Вы действительно хотите удалить товар?')"*@
<!-- Всплывающее окно -->
<div id="confirmToDelete" class="modal fade" tabindex="-1">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button class="close" type="button" data-dismiss="modal">×</button>
                <h4 class="modal-title">Подтвердите действие</h4>
            </div>
            <div class="modal-body">Вы действительно хотите удалить товар?</div>
            <div class="modal-footer">
                <a class="btn btn-danger" id="deleteConfirmed" href="">Удалить</a>
                <button class="btn btn-default" type="button" data-dismiss="modal">Закрыть</button>
            </div>
        </div>
    </div>
</div>

@section scripts{
    <!-- bootbox.js at 4.4.0 -->
<script src="https://rawgit.com/makeusabrew/bootbox/f3a04a57877cab071738de558581fbc91812dce9/bootbox.js"></script>
<script>
    $(function () {
        console.log(window);
        $('[data-toggle=confirmation]').click(function () {
            var url = $(this).attr('href');
            bootbox.confirm("Hello !", function (e) {
                if (e) {
                    location.href = url;
                }
            });
            return false;
        });
        //$('[data-toggle=confirmation]').confirmation({
        //    rootSelector: '[data-toggle=confirmation]',
        //    // other options
        //});
        
    });
</script>
}
