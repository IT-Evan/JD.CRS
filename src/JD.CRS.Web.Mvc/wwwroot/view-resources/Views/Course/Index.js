$(function () {
    //define variable
    var _courseService = abp.services.app.course;
    var _$modal = $('#CourseCreateModal');
    var _$form = _$modal.find('form[name=CourseCreateForm]');
    //var _$status = $('#Status');
    //var _$keyword = $('#Keyword');
    //var _$search = $('#Search');
    var _$dataTable = $('#dataTable');
    //Set DataTable
    $.fn.dataTable.ext.buttons.alert = {
        className: 'buttons-alert',

        action: function (e, dt, node, config) {
            _$modal.modal('show');
        }
    };
    $(document).ready(function () {
        _$dataTable.DataTable({
            aLengthMenu: [[10, 25, 50, -1], [10, 25, 50, "全部"]], //PageSize
            pagingType: "full_numbers", //Type
            scrollY: 470, //Scroll
            //dom: 'Blfrtip', //Layout
            dom: "<'row'<'col-sm-8'B><'col-sm-4'lf>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-6'i><'col-sm-6'p>>", //Layout
            //Button
            //buttons:
            //[ 
            //'copy', //复制到剪贴板
            //'csv', //导出CSV
            //'excel', //导出Excel
            //'pdf', //导出PDF
            //'print' //打印
            //],
            //Button
            buttons:
            [
                {
                    extend: 'alert',
                    text: '+'
                    //text: '<i class="material-icons">add</i>'
                },
                {
                    extend: 'copy',
                    text: 'Copy'
                },
                {
                    extend: 'csv',
                    text: 'CSV',
                    bom: true
                },
                {
                    extend: 'excel',
                    text: 'Excel'
                },
                {
                    extend: 'pdf',
                    text: 'PDF',
                    bom: true
                },
                {
                    extend: 'print',
                    text: 'Print'
                    //text: '<i class="material-icons">print</i>'
                }
            ],
            oLanguage: { //Language
                //"sUrl": "~/lib/dataTables/Language/zh-cn.json"
                "sEmptyTable": "无数据",
                "sInfo": "显示第 _START_ 至 _END_ 项记录，共 _TOTAL_ 项",
                "sInfoEmpty": "显示第 0 至 0 项记录 / 共 0 项",
                "sInfoFiltered": "(从 _MAX_ 条记录过滤)",
                "sInfoPostFix": "",
                "sThousands": ",",
                "sLengthMenu": "_MENU_ 项/页",
                "sLoadingRecords": "载入中...",
                "sProcessing": "处理中...",
                "sSearch": "过滤:",
                "sZeroRecords": "没找到匹配的记录",
                "oPaginate": {
                    "sFirst": "首页",
                    "sPrevious": "上页",
                    "sNext": "下页",
                    "sLast": "末页"
                },
                "oAria": {
                    "sSortAscending": ": 升序排序",
                    "sSortDescending": ": 降序排序"
                }
            }
        });
    });
    //Search
    //_$search.click(function () {
    //    location.href = '/Course?status=' + _$status.val() + '&keyword=' + _$keyword.val();
    //});
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