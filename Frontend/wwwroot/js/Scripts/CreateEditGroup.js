function ValidateGroup(event, form) {
    debugger;
    event.preventDefault();
    var form = $(form);
    form.validate({
    });
    if (!form.valid()) {
        return;
    } else {
        var url = form.attr('action'); 

       
        var group = form.serializeJSON();

        var groupId = $('#GroupId').val();
        if (groupId != "") {
           
        
            url = '/Group/UpdateGroup';
        }
       

        $.ajax({
            url: url,
            type: "POST",
            data: JSON.stringify(group),
            processData: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            success: function (data) {
                new $.fn.dataTable.Api('#AllGroup').draw(false);
                $('#createEdit-info-modal').modal('hide');
                toastr.options.closeButton = true;

                toastr.options.positionClass = 'toast-bottom-right';
                toastr.options.newestOnTop = true;
                $("form :input").attr("autocomplete", "on");

                toastr.success(data.message);
            },
            error: function (xhr, ajaxOptions, thrownError) {
            
                toastr.error(ajaxOptions + ": " + thrownError);
               
            }
        });
        
    }
}
$(document).ready(function () {
    $('#Category').select2({
        language: "es",
        theme: "classic",
        //tags:true,
        placeholder: 'Categories',
        allowClear: true,
        minimumInputLength: 0,
        ajax: {
            quietMillis: 150,
            url: '/GetAllCategories',
            dataType: 'json',
            data: function (params) {
                var query = {
                    searchTerm: params.term,
                    pageNum: params.page || 1,
                    pageSize: 10,
                }
               
                return query;
            },
            error: function (xhr, ajaxOptions, thrownError) {
            },
            results: function (data, page) {
                return data;
            },
            'processResults': function (data) {

                return {
                    'results': data.results
                    , 'pagination': {
                        'more': data.more
                    }
                };
            }
        },

        templateResult: function (state) {
            if (!state.id) {
                return state.text;
            }
            return state.text;
        },
        templateSelection: function (state) {
            $(state.element).attr('data-test-date', state.testDate);
            return state.text;
        }
    }).on('change', function (e) {
  
    });

});

