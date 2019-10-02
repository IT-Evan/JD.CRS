(function () {
    $(function () {

        var _courseService = abp.services.app.course;
        var _$modal = $('#CourseCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshCourseList();
        });

        $('.delete-course').click(function () {
            var courseId = $(this).attr("data-course-id");
            var courseName = $(this).attr('data-course-name');
            deleteCourse(courseId, courseName);
        });


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

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var course = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js         

            abp.ui.setBusy(_$modal);
            _courseService.create(course).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!

            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });


        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();

        });


        function refreshCourseList() {
            location.reload(true); //reload page to see new user!

        }

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
    });
})();