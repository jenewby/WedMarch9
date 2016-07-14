$('document').ready(function () {

    $('#armbtn').click(function () {
        arm();
    })

function arm() {
    //var str = ""; needed to use .text
    for (var i = 100; i < 1000; i++) {
        var string = i.toString();
        //alert(string);
        var a = parseInt(string.substring(0, 1));
        var b = parseInt(string.substring(1, 2));
        var c = parseInt(string.substring(2, 3));
        var total = Math.pow(a, 3) + Math.pow(b, 3) + Math.pow(c, 3);

        if (total === i) {
            //str = str + " " +i;
            $('#armDisplay').append(i + ", ");
            //alert(i);
        }


    }
    //$('#armDisplay').text(str);
}
});