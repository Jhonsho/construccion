/* ==========================================
   ORDUZ - script.js v1
   ========================================== */

// Cambiar apariencia del encabezado al hacer scroll
const header = document.getElementById("header");

window.addEventListener("scroll", () => {
    if (window.scrollY > 80) {
        header.style.background = "rgba(30,30,30,.95)";
        header.style.boxShadow = "0 8px 25px rgba(0,0,0,.20)";
    } else {
        header.style.background = "rgba(25,25,25,.35)";
        header.style.boxShadow = "none";
    }
});

// Animación de aparición al hacer scroll
const elementos = document.querySelectorAll(
    ".card, .galeria img, .estadisticas div, .hero-content, form"
);

elementos.forEach(el => {
    el.style.opacity = "0";
    el.style.transform = "translateY(40px)";
    el.style.transition = "all .7s ease";
});

const observer = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.style.opacity = "1";
            entry.target.style.transform = "translateY(0)";
            observer.unobserve(entry.target);
        }
    });
}, {
    threshold: 0.15
});

elementos.forEach(el => observer.observe(el));

// Botón volver arriba
const topButton = document.createElement("button");
topButton.innerHTML = "↑";
topButton.title = "Volver arriba";
topButton.style.position = "fixed";
topButton.style.right = "20px";
topButton.style.bottom = "20px";
topButton.style.width = "48px";
topButton.style.height = "48px";
topButton.style.borderRadius = "50%";
topButton.style.border = "none";
topButton.style.background = "#6b4f35";
topButton.style.color = "#fff";
topButton.style.fontSize = "22px";
topButton.style.cursor = "pointer";
topButton.style.boxShadow = "0 8px 20px rgba(0,0,0,.2)";
topButton.style.display = "none";
topButton.style.zIndex = "9999";

document.body.appendChild(topButton);

window.addEventListener("scroll", () => {
    topButton.style.display = window.scrollY > 500 ? "block" : "none";
});

topButton.addEventListener("click", () => {
    window.scrollTo({
        top: 0,
        behavior: "smooth"
    });
});

// Formulario
const form = document.querySelector("form");

if (form) {
    form.addEventListener("submit", (e) => {
        e.preventDefault();
        alert("Gracias por tu solicitud. Próximamente integraremos el envío automático por WhatsApp.");
        form.reset();
    });
}