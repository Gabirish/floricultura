$(document).ready(function () {

    var table = $('table');

    $('#nome, #custo, #estoque, #estado, #cidade, #vendedor, #cliente, #data')
        .wrapInner('<span title="sort this column"/>')
        .each(function () {

            var th = $(this),
                thIndex = th.index(),
                inverse = false;

            th.click(function () {

                table.find('td').filter(function () {

                    return $(this).index() === thIndex;

                }).sortElements(function (a, b) {
                    if ($.text([a]).includes("R$")) {

                        var c = parseFloat($.text([a]).replace("R$", " ").replace(",", ".").trim());
                        var d = parseFloat($.text([b]).replace("R$", " ").replace(",", ".").trim());

                        return c > d ?
                            inverse ? -1 : 1
                            : inverse ? 1 : -1;
                    } else
                    {
                        return $.text([a]) > $.text([b]) ?
                            inverse ? -1 : 1
                            : inverse ? 1 : -1;
                    }
                }, function () {

                    // parentNode is the element we want to move
                    return this.parentNode;

                });

                inverse = !inverse;

            });

        });
});