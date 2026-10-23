// Write your JavaScript code.


hamburger = document.querySelector(".hamburger");
hamburger.onclick = function () {
    navBar = document.querySelector(".nav-bar");
    navBar.classList.toggle("active");
}




var icon = document.getElementById("icon");
icon.onclick = function () {
    document.body.classList.toggle("light-mode");
    if (document.body.classList.contains("light-mode")) {
        icon.src = "/css/moon_5-removebg-preview.png"; 
    } else {
        icon.src = "/css/sun 6.png"; 
    }
}




const boxes = document.querySelectorAll('.box')
window.addEventListener('scroll', checkBoxes)
checkboxes()

function checkBoxes() {
    const triggerBottom = window.innerHeight / 5 * 4
    boxes.forEach(box => {
        const boxTop = box.getBoundingClientRect().top
        if (boxTop < triggerBottom) {
            box.classList.add('show')
        } else {
            box.classList.remove('show')

        }
    })
}



