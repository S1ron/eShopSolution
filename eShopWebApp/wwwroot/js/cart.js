var CartController = function () {
    this.initialize = function () {
        loadData();
        regsiterEvents()
    }

    function regsiterEvents() {
        $('body').on('click', '.btn-plus', function (e) {
            e.preventDefault();
            const culture = $('#hidCulture').val();
            const id = $(this).data('id');
            $.ajax({
                type: "POST",
                url: "/" + culture + '/Cart/AddToCart',
                data: {
                    id: id,
                    languageId: culture
                },
                success: function (res) {
                    $('#lbl_number_items_header').text(res.length);
                    loadData()
                    loadCart()
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });

        $('body').on('click', '.btn-minus', function (e) {
            e.preventDefault();
            const culture = $('#hidCulture').val();
            const id = $(this).data('id');
            $.ajax({
                type: "POST",
                url: "/" + culture + '/Cart/UpdateCart',
                data: {
                    id: id,
                    quantity: -1
                },
                success: function (res) {
                    $('#lbl_number_items_header').text(res.length);
                    loadData()
                    loadCart()
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });

        $('body').on('click', '.btn-remove', function (e) {
            e.preventDefault();
            const culture = $('#hidCulture').val();
            const id = $(this).data('id');
            $.ajax({
                type: "POST",
                url: "/" + culture + '/Cart/UpdateCart',
                data: {
                    id: id,
                    quantity: 0
                },
                success: function (res) {
                    $('#lbl_number_items_header').text(res.length);
                    loadData()
                    loadCart()
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });
    }

    function loadData() {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: "GET",
            url: "/" + culture + '/Cart/GetListItems',
            success: function (res) {
                var html = '';
                var total = 0;
                $.each(res, function (i, item) {
                    var amount = item.price * item.quantity;
                    html += "<tr>"
                        + "<td> <img width=\"60\" src=\"" + $('#hidBaseAddress').val()+ "/user-content/"+ item.image + "\" alt=\"\" /></td>"
                        + "<td>" + item.description + "</td>"
                        + "<td><div class=\"input append\"><input class=\"span1\" value=\"" + item.quantity + "\" style=\"max-width: 34px\" placeholder=\"1\" id=\"txt_quantity_" + item.id + "\" size=\"16\" type=\"text\">"
                        + "<button class=\"btn btn-minus\" data-id=\"" + item.productId + "\" type =\"button\"> <i class=\"icon-minus\"></i></button>"
                        + "<button class=\"btn btn-plus\" type=\"button\" data-id=\""+item.productId+"\"><i class=\"icon-plus\"></i></button>"
                        + "<button class=\"btn btn-danger btn-remove\" type=\"button\" data-id=\"" + item.productId +"\"><i class=\"icon-remove icon-white\"></i></button>"
                        + "</div>"
                        + "</td>"
                        + "<td>" + numberWithCommas(item.price)+"</td>"
                        + "<td>" + numberWithCommas(amount) +"</td>"
                        + "</tr>";
                    total += amount;
                });
                $('#cart_body').html(html);
                $('#lbl_number_of_items').text(res.length);
                $('#lbl_total').text(numberWithCommas(total));

                
            }
        });
    }
}