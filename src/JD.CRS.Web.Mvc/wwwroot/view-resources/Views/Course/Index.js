$(function () {
    //define variable
    var _courseService = abp.services.app.course;
    var _$modal = $('#CourseCreateModal');
    var _$form = _$modal.find('form[name=CourseCreateForm]');
    var _$status = $('#Status');
    var _$keyword = $('#Keyword');
    var _$search = $('#Search');
    var _$dataTable = $('#dataTable');
    //Set DataTable
    $(document).ready(function () {
        _$dataTable.DataTable({
            pagingType: "full_numbers", //Type
            scrollY: 580, //Scroll
            //'<'float_left'f>r<'float_right'l>tip', //Layout
            dom: "<'row'<'col-sm-2'l><'col-sm-4'f><'col-sm-6'B>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-6'i><'col-sm-6'p>>", //Layout
            //dom: 'Bfrtip', //Layout
            buttons: [
                'copy', 'csv', 'excel', 'pdf', 'print'
            ],
            language: //Language
            {　
                "emptyTable": "No data available in table",
                "info": "Showing _START_ to _END_ of _TOTAL_ entries",
                "infoEmpty": "Showing 0 to 0 of 0 entries",
                "infoFiltered": "(filtered from _MAX_ total entries)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "PageSize _MENU_",
                "loadingRecords": "Loading...",
                "processing": "Processing...",
                "search": "Search:",
                "zeroRecords": "No matching records found",
                "paginate": {
                    "first": "First",
                    "last": "Last",
                    "next": "Next",
                    "previous": "Previous"
                },
                "aria": {
                    "sortAscending": ": activate to sort column ascending",
                    "sortDescending": ": activate to sort column descending"
                }  
            } 
        });
    });
    //Search
    _$search.click(function () {
        location.href = '/Course?status=' + _$status.val() + '&keyword=' + _$keyword.val();
    });
    //define save function for create
    function save() {
        if (!_$form.valid()) {
            return;
        }
        var course = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js   
        abp.ui.setBusy(_$form); //loading-begin
        _courseService.create(course).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page
        }).always(function () {
            abp.ui.clearBusy(_$modal); //loading-end
        });
    }
    //define refresh function
    function refreshCourseList() {
        location.reload(true); //reload page to see new user!
    }
    //define delete function
    function deleteCourse(courseId, courseName) {
        abp.message.confirm(
            abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'CRS'), courseName),
            function (isConfirmed) {
                if (isConfirmed) {
                    _courseService.delete({
                        id: courseId
                    }).done(function () {
                        refreshCourseList();
                    });
                }
            }
        );
    }
    //call refresh function
    $('#RefreshButton').click(function () {
        refreshCourseList();
    });
    //call delete function
    $('.delete-course').click(function () {
        var courseId = $(this).attr("data-course-id");
        var courseName = $(this).attr('data-course-name');
        deleteCourse(courseId, courseName);
    });
    //call edit function
    $('.edit-course').click(function (e) {
        var courseId = $(this).attr("data-course-id");
        e.preventDefault();
        $.ajax({
            url: abp.appPath + 'Course/EditCourseModal?courseId=' + courseId,
            type: 'POST',
            contentType: 'application/html',
            success: function (content) {
                $('#CourseEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });
    //call save function
    _$form.find('button[type="submit"]').click(function (e) {
        e.preventDefault();
        save();        
    });
    //focus first input
    _$modal.on('shown.bs.modal', function () {
        _$modal.find('input:not([type=hidden]):first').focus();
    });
});