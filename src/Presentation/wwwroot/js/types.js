const types = [];
const type = [];

async function renderTypes(data = []) {
    let typeElement = document.getElementById('type-list');
    let content = '';

    if(data.length > 0) {
        data.map((item) => {
            content += '<tr>';
            content += `<td><a class="p-2" href="/Types/Edit?id=${item.id}">${item.name}</td>`;
            content += `<td>${item.category}</td>`;
            content += `<td>${item.description.substring(0, 15)}...</td>`;
            content += `<td>${item.createdBy}</td>`;
            content += `<td>${item.createdAt}</td>`;
            content += `<td>${item.updatedBy}</td>`;
            content += `<td>${item.updatedAt}</td>`;
            content += '</tr>';
        });
    }

    if(typeElement) {
        typeElement.innerHTML = '';
        typeElement.innerHTML = content;
    }

}

async function renderCategories() {
    let categoryElement = document.getElementById('product-category');
    let data = await getCategories();

    if(data.length > 0) {
        data.forEach(item => {
            let option = document.createElement('option');
            option.value = item.id;
            option.textContent = item.name;

            if(type[0]?.productCategoryId && type[0]?.productCategoryId == item.id) {
                option.selected = true;
            } 

            categoryElement.appendChild(option);
        });
    }

    categoryElement.addEventListener('change', () => renderTypes(categoryElement.value));
}

async function renderTypeData(id = '') {
    let result = await getTypeById(id);
    type.push(result);
}

function renderFormData() {
    let id = document.getElementById('type-id');
    let name = document.getElementById('type-name');
    let description = document.getElementById('type-description');

    id.value = type[0]?.id;
    name.value = type[0]?.name;
    description.value = type[0]?.description;
}

function search(value = '') {
    let filtedValues = types;
    value = value.toLowerCase();

    if(value.length > 0) {
        filtedValues = filtedValues.filter(item => {     
            if(item.name.toLowerCase().includes(value) ||
            item.description.toLowerCase().includes(value) ||
            item.category.toLowerCase().includes(value)) {
                return item;
            }
        });
    }

    renderTypes(filtedValues);
}

(document.onload = async () => {
    if(params.id) {
        let btnDelete = document.getElementById('btn-delete');
        btnDelete.addEventListener('click', async () => await deleteRecord(params.id, 'Types', 'OnDelete'));
        await renderTypeData(params.id);
        await renderCategories();
        renderFormData();
    }

    let btnSearch = document.getElementById('btn-search');
    btnSearch.addEventListener('click', (e) => {
        e.preventDefault();

        let searchInput = document.getElementById('search-input');
        search(searchInput.value);
    });

    let results = await getTypesView();
    types.push(...results);
    await renderTypes(types);
})();