/*
(function (cibertec) {
    cibertec.Index = {
        currentYear: function () {
            var today = new Date();
            return today.getFullYear();
        }
    };
    document.getElementById("date").innerHTML = cibertec.Index.currentYear();
})(window.cibertec = window.cibertec || {});
*/

window.onload = function(){
    var today = new Date().getFullYear();
    console.log(today);
    document.getElementById("date").innerHTML = today;
};
