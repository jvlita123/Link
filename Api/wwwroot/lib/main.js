const mainDropdownToggle = document.getElementById('dropdown-toggle');
const mainDropdownContent = document.getElementById('main-dropdown-content');

mainDropdownToggle.addEventListener('click', (e) => {
    mainDropdownContent.classList.toggle('hidden');
});
