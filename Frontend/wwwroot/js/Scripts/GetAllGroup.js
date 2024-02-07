function createUpdateGroup(event, object) {
    event.stopPropagation();

    var groupId = $(object).attr('data-group-id');
    debugger;
    var url = groupId === undefined ? 'CreateEditGroup/' : 'CreateEditGroup/' + groupId;
   
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
    $('#AllGroup').DataTable({
        columns: [
            { data: 'groupName' },
            { data: 'category.categoryName' },

            {
                title: 'Action',
                render: function (data, type, row, meta) {
                    return `<button data-group-id="${row.groupId}" onclick="createUpdateGroup(event,this);" class="createUpdateGroup btn btn-primary">Edit</button>`;

                }
            }
        ],
        rowId: function (row) {
            return row.groupId;
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
            method: "Post",
            url: '/Group/GetTable',

            error: function (xhr, ajaxOptions, thrownError) {


            },
            data: function (data, settings) {

                console.log(data);
                return { DTParameterModel: { Length: data.length, Start: data.start, Draw: data.draw, order: data.order, columns: data.columns, } }
            }

        }
    });
});  