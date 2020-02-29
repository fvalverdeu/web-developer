(function (cibertec) {
    window.cibertec.getLocation = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition);
        }
    }

    function showPosition(position) {
        var location = {
            lat: -12.0860837, //position.coords.latitude,
            lng: -77.0488065 //position.coords.longitude
        };
        console.log("Latitud: " + location.lat);
        console.log("Longitud: " + location.lng);
        var map = new google.maps.Map(document.getElementById('googleMap'),
            {
                zoom: 15,
                center: location
            });
        var marker = new google.maps.Marker({
            position: location,
            map: map,
            title: 'Cibertec!'
        });
    }

})(window.cibertec = window.cibertec || {});