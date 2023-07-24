function hellpWorld() {
    alert("Hello world");
}
document.addEventListener('click', e => {
    const isDropdownLink = e.target.matches("[data-dropdown-link]")
    if (!isDropdownLink && e.target.closest('[data-dropdown]') != null) return
    let curentDropDown
    if (isDropdownLink) {
        curentDropDown = e.target.closest('[data-dropdown]')
        curentDropDown.classList.toggle('active')
    }
    document.querySelectorAll("[data-dropdown].active").forEach(dropdown => {
        if (dropdown === curentDropDown) return
        dropdown.classList.remove('active')
    })
})


$(document).ready(function () {
    $('#myLink').click(function (event) {
        event.preventDefault(); // Prevent the default behavior of the link

        var inputTag = $('<input>', {
            type: 'text',
            value: 'Input Value'
        });

        $(this).replaceWith(inputTag);
    });
});

function submitForm() {
    document.getElementById("commentForm").submit();
}

