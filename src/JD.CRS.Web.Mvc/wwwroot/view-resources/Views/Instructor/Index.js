$(function () {
    //define variable
    var _instructorService = abp.services.app.instructor;
    var _$modal = $('#CreateModal');
    var _$form = _$modal.find('form[name=CreateForm]'); 
    //var _$status = $('#Status');
    //var _$keyword = $('#Keyword');
    //var _$search = $('#Search');
    var _$dataTable = $('#dataTable');
    //Bind Add Button to CreateModal
    $.fn.dataTable.ext.buttons.alert = {
        className: 'buttons-alert',

        action: function (e, dt, node, config) {
            _$modal.modal('show'); //Show the CreateModal
        }
    };
    //Set DataTable
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
                {// 自定义按钮-Add
                    extend: 'alert',
                    text: '+'
                    //text: '<i class="material-icons">add</i>'
                },
                { //复制到剪贴板
                    extend: 'copy',
                    text: 'Copy'
                },
                { //导出CSV
                    extend: 'csv',
                    text: 'CSV',
                    bom: true
                },
                { //导出Excel
                    extend: 'excel',
                    text: 'Excel'
                },
                { //导出PDF
                    extend: 'pdf',
                    text: 'PDF'
                },
                { //打印
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
                "sSearch": '<i class="material-icons">search</i>',
                "sZeroRecords": "没找到匹配的记录",
                "oPaginate": {
                    "sFirst": "|<",
                    "sPrevious": "<",
                    "sNext": ">",
                    "sLast": ">|"
                },
                "oAria": {
                    "sSortAscending": ": 升序排序",
                    "sSortDescending": ": 降序排序"
                }
                //defaultStyle: {
                //    font: '微软雅黑'
                //}
            }
        });
        //pdfMake.fonts = {
        //    Roboto: {
        //        normal: 'Roboto-Regular.ttf',
        //        bold: 'Roboto-Medium.ttf',
        //        italics: 'Roboto-Italic.ttf',
        //        bolditalics: 'Roboto-Italic.ttf'
        //    },
        //    微软雅黑: {
        //        normal: 'msyh.ttf',
        //        bold: 'msyh.ttf',
        //        italics: 'msyh.ttf',
        //        bolditalics: 'msyh.ttf',
        //    }
        //};
    });
    //Search
    //_$search.click(function () {
    //    location.href = '/Instructor?status=' + _$status.val() + '&keyword=' + _$keyword.val();
    //});
    //define save function for create
    function save() {
        if (!_$form.valid()) {
            return;
        }
        var instructor = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js   
        abp.ui.setBusy(_$form); //loading-begin
        _instructorService.create(instructor).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page
        }).always(function () {
            abp.ui.clearBusy(_$modal); //loading-end
        });
    }
    //define refresh function
    function refreshInstructorList() {
        location.reload(true); //reload page to see new user!
    }
    //define delete function
    function deleteInstructor(instructorId, instructorName) {
        abp.message.confirm(
            abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'CRS'), instructorName),
            function (isConfirmed) {
                if (isConfirmed) {
                    _instructorService.delete({
                        id: instructorId
                    }).done(function () {
                        refreshInstructorList();
                    });
                }
            }
        );
    }
    //call refresh function
    $('#RefreshButton').click(function () {
        refreshInstructorList();
    });
    //call delete function
    $('.delete-instructor').click(function () {
        var instructorId = $(this).attr("data-instructor-id");
        var instructorName = $(this).attr('data-instructor-name');
        deleteInstructor(instructorId, instructorName);
    });
    //call edit function
    $('.edit-instructor').click(function (e) {
        var instructorId = $(this).attr("data-instructor-id");
        e.preventDefault();
        $.ajax({
            url: abp.appPath + 'Instructor/Edit?instructorId=' + instructorId,
            type: 'POST',
            contentType: 'application/html',
            success: function (content) {
                $('#EditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });
    //call save function
    _$form.find('button[type="submit"]').click(function (e) {
        e.preventDefault();
        save();        
    });
    //initial form
    _$modal.on('shown.bs.modal', function () {
        _$modal.find('input:not([type=hidden]):first').focus();//focus first input
        laydate.render({
            elem: '#HireDate' //bind laydate
        });
    });
});