
$(function () {
    $("#CheckAll").click(function () {
        checkAll();
    });
});
function checkAll() {
    var isCheckAll = $("#CheckAll").prop('checked');
    $(".checkItem").each(function (i, e) {
        $(e).prop('checked', isCheckAll);
    })
}