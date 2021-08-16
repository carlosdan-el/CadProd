const categories = [];
const category = [];

async function renderCategories(data = []) {
    let categoryElement = document.getElementById('category-list');
    let content = '';

    if(data.length > 0) {
        data.map((item) => {
            content += '<tr>';
            content += `<td><a class="p-2" href="/Categories/Edit?id=${item.id}">${item.name}</td>`;
            content += `<td>${item.description.substring(0, 15)}...</td>`;
            content += `<td>${item.createdBy}</td>`;
            content += `<td>${item.createdAt}</td>`;
            content += `<td>${item.updatedBy}</td>`;
            content += `<td>${item.updatedAt}</td>`;
            content += '</tr>';
        });
    }

    if(categoryElement) {
        categoryElement.innerHTML = '';
        categoryElement.innerHTML = content;
    }
}

async function renderCategoryData(id) {
    let result = await getCategoryById(id);
    category.push(result);
}

function renderFormData() {
    let id = document.getElementById('category-id');
    let name = document.getElementById('category-name');
    let description = document.getElementById('category-description');

    id.value = category[0]?.id;
    name.value = category[0]?.name;
    description.value = category[0]?.description;
}

function search(value = '') {
    let filtedValues = categories;
    value = value.toLowerCase();

    if(value.length > 0) {
        filtedValues = filtedValues.filter(item => {     
            if(item.name.toLowerCase().includes(value) ||
            item.description.toLowerCase().includes(value)) {
                return item;
            }
        });
    }

    renderCategories(filtedValues);
}

(document.onload = async () => {

    if(params.id) {
        let btnDelete = document.getElementById('btn-delete');
        btnDelete.addEventListener('click', async () => await deleteRecord(params.id, 'Categories', 'OnDelete'));
        await renderCategoryData(params.id);
        renderFormData();
    }

    let btnSearch = document.getElementById('btn-search');
    btnSearch.addEventListener('click', (e) => {
        e.preventDefault();

        let searchInput = document.getElementById('search-input');
        search(searchInput.value);
    });

    let results = await getCategoriesView();
    categories.push(...results);
    await renderCategories(categories);
})();