﻿$(function () {
    //define variable
    var _instructorCourseService = abp.services.app.instructorCourse;
    var _$modal = $('#EditModal');
    var _$form = $('form[name=EditForm]');
    var _$status = $('#Status');
    //Initial form
    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();//focus first input
        _$status.val() = status;//Status value
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
        var instructorCourse = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js   
        abp.ui.setBusy(_$form); //loading-begin
        _instructorCourseService.update(instructorCourse).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page
        }).always(function () {
            abp.ui.clearBusy(_$modal); //loading-end
        });
    }
});