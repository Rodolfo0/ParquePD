let navbar = document.getElementById("navbar");
let navbarToggle = document.getElementById("navbar__toggle");
let menu=document.getElementById("menu-list");

navbarToggle.addEventListener("click", function () {
    navbar.classList.toggle("activeNavbar");
});


let profile = document.getElementById("header-perfil");
let adminProfile = document.getElementById("administrar-perfil");

profile.addEventListener("click", function () {
    adminProfile.classList.toggle("administrar-perfil--active");
});

