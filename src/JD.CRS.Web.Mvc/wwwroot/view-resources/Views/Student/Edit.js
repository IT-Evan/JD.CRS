﻿$(function () {
    //define variable
    var _studentService = abp.services.app.student;
    var _$modal = $('#EditModal');
    var _$form = $('form[name=EditForm]');
    var _$status = $('#Status');
    //Initial form
    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();//focus first input
        _$status.val() = status;//Status value
        laydate.render({
            elem: '#EnrollmentDate' //bind laydate
        });
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
        var student = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js   
        abp.ui.setBusy(_$form); //loading-begin
        _studentService.update(student).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page
        }).always(function () {
            abp.ui.clearBusy(_$modal); //loading-end
        });
    }
});