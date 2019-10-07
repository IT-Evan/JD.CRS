$(function () {
    //define var
    var _courseService = abp.services.app.course;
    var _$modal = $('#CourseEditModal');
    var _$form = $('form[name=CourseEditForm]');
    //save for create
    function save() {
        if (!_$form.valid()) {
            return;
        }
        var course = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js   
        abp.ui.setBusy(_$form); //loading-begin
        _courseService.update(course).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page
        }).always(function () {
            abp.ui.clearBusy(_$modal); //loading-end
        });
    }
    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });
    //$.AdminBSB.input.activate(_$form);
    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();

    });
});