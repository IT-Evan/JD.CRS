$(function () {
    //define variable
    var _officeInstructorService = abp.services.app.officeInstructor;
    var _$modal = $('#EditModal');
    var _$form = $('form[name=EditForm]');
    var _$status = $('#Status');
    var _$office = $('#OfficeCode');
    var _$instructor = $('#InstructorCode');
    //Initial form
    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();//focus first input
        _$status.val() = status;//Status value
        _$office.val() = office;//Office value
        _$instructor.val() = instructor;//Instructor value
    });
    //call save function
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });
    //define save function for create
    function save() {
        if (!_$form.valid()) {
            return;
        }
        var officeInstructor = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js   
        abp.ui.setBusy(_$form); //loading-begin
        _officeInstructorService.update(officeInstructor).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page
        }).always(function () {
            abp.ui.clearBusy(_$modal); //loading-end
        });
    }
});