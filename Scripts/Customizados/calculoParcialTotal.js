
function myFunction($this) {
    $($this).parent().siblings(":last").find('label').text(("R$ " + ($($this).parent().siblings().eq(1).text().replace(",", ".") * $this.value).toFixed(2)).replace(".", ","));
    var total;

    var sum = 0.0;
    $('.valores').each(function () {
        sum += parseFloat($(this).text().replace("R$ ", "").replace(",", ".").replace("_", 0));
    });

    $('#total').val(("R$ " + sum.toFixed(2)).replace(".", ","));
}
