function createUpdateCategory(event, object) {
    event.stopPropagation();

    var categoryId = $(object).attr('data-category-id');
    var url = categoryId === undefined ? 'Category/CreateEditCategory/' : 'Category/CreateEditCategory/' + categoryId;

    $.ajax({
        method: 'Get',
        url: url,
        error: function (xhr, ajaxOptions, thrownError) {

        },
        success: function (view) {

            $('#createUpdateForm').html(view);
            $('#createEdit-info-modal').modal('show');

        }

    });
}

$(document).ready(function () {
    $('#AllCategory').DataTable({
        columns: [
            { data: 'categoryName' },
            {
                title: 'Action',
                render: function (data, type, row, meta) {
                    return `<button data-category-id="${row.categoryId}" onclick="createUpdateCategory(event,this);" class="createUpdateCategory btn btn-primary">Edit</button>`;
                }
            }
        ],
        rowId: function (row) {
            return row.categoryId
        },
        paging: true,
        searching: true,
        ordering: true,
        autoWidth: true,
        pageLength: 10,
        processing: true,
        serverSide: true,
        ajax: {
            quietMillis: 150,
            type: "Post",
            url: '/Category/GetAllCategory',
            error: function (xhr, ajaxOptions, thrownError) {

               
            },
            data: function (data, settings) {


                return { DTParameterModel: { Length: data.length, Start: data.start, Draw: data.draw, order: data.order, columns: data.columns, data: data.searching } }
            }

        }
    });
});  