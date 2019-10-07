$(function () {
    //define var
    var _courseService = abp.services.app.course;
    var _$modal = $('#CourseCreateModal');
    var _$form = _$modal.find('form[name=CourseCreateForm]');
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