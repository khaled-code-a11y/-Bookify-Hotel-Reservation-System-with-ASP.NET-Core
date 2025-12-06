
/**
 * بيانات الفنادق الموحدة (مستخرجة من index.html)
 * ملاحظة: يجب وضع هذا الكود في بداية ملف main.js
 */
let HOTELS_DATA = {};

async function fetchAndRenderRooms() {
    const rooms = await api.getAllRooms();
    const roomsContainer = document.getElementById('roomsContainer');

    if (roomsContainer) {
        roomsContainer.innerHTML = '';
    }

    rooms.forEach(room => {
        // Map API data to frontend structure
        const hotelData = {
            id: room.id,
            name: `Room ${room.roomNumber} - ${room.roomType}`,
            location: 'Amunra Hotel',
            address: 'Amunra Hotel',
            image: room.roomPhotoUrl || 'img/default-room.jpg',
            totalPrice: room.price,
            rating: 4.5,
            badge: room.isAvailable ? 'Available' : 'Booked',
            type: room.roomType.toLowerCase(), // For filtering
            bed: room.capacity > 1 ? 'double' : 'single', // Approximate mapping
            description: room.description
        };

        // Store in global data for search
        HOTELS_DATA[room.id] = hotelData;

        // Render in rooms page if container exists
        if (roomsContainer) {
            const roomElement = document.createElement('article');
            roomElement.className = 'room-item';
            roomElement.dataset.bed = hotelData.bed;
            roomElement.dataset.type = hotelData.type;
            roomElement.dataset.price = hotelData.totalPrice;

            roomElement.innerHTML = `
                <div class="room-media">
                    <img src="${hotelData.image}" alt="${hotelData.name}" onerror="this.src='img/default-room.jpg'" />
                </div>
                <div class="room-info">
                    <h3 class="room-title">${hotelData.name}</h3>
                    <p class="room-sub">${hotelData.location}</p>
                    <p class="room-desc">
                        ${hotelData.description || 'No description available.'}
                    </p>

                    <div class="room-meta">
                        <span class="amenity">free wifi</span>
                        <span class="amenity">free breakfast</span>
                        <span class="amenity">room service</span>
                    </div>

                    <div class="room-bottom">
                        <div class="room-price">$${hotelData.totalPrice} <span>/day</span></div>
                        <div>
                            <a class="btn-outline" href="hotel.html?id=${hotelData.id}">View Details</a>
                            <a class="btn-primary" href="booking.html?id=${hotelData.id}">Book Now</a>
                        </div>
                    </div>
                </div>
            `;
            roomsContainer.appendChild(roomElement);
        }
    });

    // Re-initialize filters if on rooms page
    if (roomsContainer) {
        initializeFilters();
    }
}

// Call fetch on load
document.addEventListener('DOMContentLoaded', fetchAndRenderRooms);






/* ======================================= */
/* 7. Header Search Functionality */
/* ======================================= */
// الكود الذي يجب أن يكون موجوداً حالياً:


const hotelsData = HOTELS_DATA;
const toggleSearchBtn = document.getElementById('toggleSearchBtn');
const searchHeaderInput = document.getElementById('searchHeaderInput');
const closeSearchInput = document.getElementById('closeSearchInput');
const headerSearchInput = document.getElementById('headerSearchInput');
const searchResults = document.getElementById('searchResults');

// 1. وظيفة الإظهار والإخفاء
// في ملف main.js، ضمن قسم 7. Header Search Functionality

if (toggleSearchBtn && searchHeaderInput && closeSearchInput) {
    toggleSearchBtn.addEventListener('click', function () {
        searchHeaderInput.classList.toggle('hidden');
        headerSearchInput.value = '';
        searchResults.classList.add('hidden');
        if (!searchHeaderInput.classList.contains('hidden')) {
            headerSearchInput.focus();
        }
    });

    closeSearchInput.addEventListener('click', function () {
        searchHeaderInput.classList.add('hidden');
        headerSearchInput.value = '';
        searchResults.classList.add('hidden');
    });
}

// 2. منطق البحث
if (headerSearchInput && searchResults) {
    // يجب استخدام نفس بيانات الفنادق الموجودة في my-bookings.html
    const hotelsData = HOTELS_DATA; // يفترض أن HOTELS_DATA معرفة عالمياً أو في بداية الملف

    headerSearchInput.addEventListener('input', function () {
        const query = this.value.trim().toLowerCase();

        if (query.length < 2) {
            searchResults.classList.add('hidden');
            return;
        }

        let resultsHtml = '';

        // البحث عبر جميع الفنادق
        for (const id in hotelsData) {
            const hotel = hotelsData[id];
            const hotelName = hotel.name.toLowerCase();

            if (hotelName.includes(query)) {
                resultsHtml += `
                    <a href="hotel.html?id=${id}" class="search-result-item">
                        ${hotel.name}
                    </a>
                `;
            }
        }

        if (resultsHtml) {
            searchResults.innerHTML = resultsHtml;
            searchResults.classList.remove('hidden');
        } else {
            searchResults.innerHTML = `<span class="search-result-item">No hotels found.</span>`;
            searchResults.classList.remove('hidden');
        }
    });
}






document.addEventListener('DOMContentLoaded', function () {

    /* ======================================= */
    /* 1. Hamburger Menu Toggle (شريط التنقل) */
    /* ======================================= */
    const hamburger = document.getElementById('hamburger');
    const navbar = document.getElementById('navbar');

    if (hamburger && navbar) {
        hamburger.addEventListener('click', function () {
            hamburger.classList.toggle('active');
            navbar.classList.toggle('active');
        });

        // إغلاق القائمة عند الضغط على أي رابط
        document.querySelectorAll('#navbar a').forEach(link => {
            link.addEventListener('click', () => {
                hamburger.classList.remove('active');
                navbar.classList.remove('active');
            });
        });
    }

    /* ======================================= */
    /* 2. Featured Hotels "View All" (صفحة index) */
    /* ======================================= */
    const viewMoreHotelsButton = document.getElementById('viewMoreHotels');
    const additionalHotels = document.getElementById('additionalHotels');

    if (viewMoreHotelsButton && additionalHotels) {
        viewMoreHotelsButton.addEventListener('click', function () {
            const isHidden = additionalHotels.classList.contains('hidden');
            additionalHotels.classList.toggle('hidden', !isHidden);
            additionalHotels.classList.toggle('show', isHidden);
            this.textContent = isHidden ? 'Show Less' : 'View All Details';
        });
    }


    /* ======================================= */
    /* 3. Exclusive Offers "View All" (صفحة index) */
    /* ======================================= */
    const viewMoreOffersButton = document.getElementById('viewMoreOffers');
    const additionalOffers = document.getElementById('additionalOffers');

    if (viewMoreOffersButton && additionalOffers) {
        viewMoreOffersButton.addEventListener('click', function () {
            const isHidden = additionalOffers.classList.contains('hidden');
            additionalOffers.classList.toggle('hidden', !isHidden);
            additionalOffers.classList.toggle('show', isHidden);
            this.textContent = isHidden ? 'Show Less' : 'View All Offers';
        });
    }


    /* ======================================= */
    /* 4. Rooms "Show More" (صفحة rooms) */
    /* ======================================= */
    const btnRooms = document.getElementById('viewMoreRooms');
    const additionalRooms = document.getElementById('additionalRooms');

    if (btnRooms && additionalRooms) {
        btnRooms.addEventListener('click', function () {
            const opening = additionalRooms.classList.contains('hidden_rooms');
            additionalRooms.classList.toggle('hidden_rooms', !opening);
            additionalRooms.classList.toggle('show_rooms', opening);
            btnRooms.setAttribute('aria-expanded', opening ? 'true' : 'false');
            btnRooms.textContent = opening ? 'Show Less' : 'Show More';

            if (opening) {
                // التمرير إلى أول عنصر جديد
                setTimeout(() => {
                    const first = additionalRooms.querySelector('.room-item');
                    first && first.scrollIntoView({ behavior: 'smooth', block: 'start' });
                }, 80);
            } else {
                // التمرير إلى الزر نفسه عند الإخفاء
                btnRooms.scrollIntoView({ behavior: 'smooth', block: 'center' });
            }
        });
    }

    /* ======================================= */
    /* 5. User Dropdown Toggle (القائمة المنسدلة للحساب) */
    /* ======================================= */
    const userIcon = document.getElementById('userIcon');
    const userMenu = document.getElementById('userMenu');

    if (userIcon && userMenu) {
        userIcon.addEventListener('click', function (event) {
            // منع إغلاق القائمة عند الضغط داخلها
            event.stopPropagation();
            userMenu.classList.toggle('active');
        });

        // إغلاق القائمة عند الضغط في أي مكان خارجها
        document.addEventListener('click', function (event) {
            if (userMenu.classList.contains('active') && !userMenu.contains(event.target)) {
                userMenu.classList.remove('active');
            }
        });
    }
});


/* ======================================= */
/* 6. Manage Account Modal Toggle (القائمة المنبثقة لإدارة الحساب) */
/* ======================================= */
const manageAccountModal = document.getElementById('manageAccountModal');
const openManageModalLink = document.getElementById('openManageModalLink');
const closeManageModal = document.getElementById('closeManageModal');

// عناصر الـ Inner Modal
const openUpdateProfile = document.getElementById('openUpdateProfile');
const cancelUpdateProfile = document.getElementById('cancelUpdateProfile');
const updateProfileModal = document.getElementById('updateProfileModal');

if (manageAccountModal && openManageModalLink && closeManageModal) {

    // 1. فتح الـ Modal الرئيسي
    openManageModalLink.addEventListener('click', function (e) {
        e.preventDefault();
        manageAccountModal.classList.remove('hidden');
        // إغلاق قائمة المستخدم المنسدلة
        const userMenu = document.getElementById('userMenu');
        userMenu && userMenu.classList.remove('active');
    });

    // 2. إغلاق الـ Modal الرئيسي
    closeManageModal.addEventListener('click', function () {
        manageAccountModal.classList.add('hidden');
    });

    // 3. وظيفة Inner Modal (تحديث الصورة)
    if (openUpdateProfile && cancelUpdateProfile && updateProfileModal) {
        openUpdateProfile.addEventListener('click', function () {
            updateProfileModal.classList.remove('hidden');
        });
        cancelUpdateProfile.addEventListener('click', function () {
            updateProfileModal.classList.add('hidden');
        });
    }
}


/* ======================================= */
/* 8. Hero Search Form Handler (صفحة index) */
/* ======================================= */
document.addEventListener('DOMContentLoaded', function () {
    const searchForm = document.querySelector('.hero .search-bar');

    if (searchForm) {
        searchForm.addEventListener('submit', function (e) {
            e.preventDefault(); // منع الإرسال الافتراضي

            // 1. جمع البيانات من النموذج
            const destination = searchForm.querySelector('.location-field input').value.trim();
            const checkin = searchForm.querySelector('input[type="date"]').value.trim();
            // بما أن الـ checkout هو ثاني حقل date، يمكن الوصول إليه هكذا:
            const checkout = searchForm.querySelectorAll('input[type="date"]')[1].value.trim();
            const guests = searchForm.querySelector('select').value; // يأخذ القيمة المختارة

            // 2. التحقق البسيط
            if (!destination || !checkin || !checkout) {
                alert('Please enter Destination and Check-in/Check-out dates.');
                return;
            }

            // 3. بناء رابط Query Parameters
            const queryParams = new URLSearchParams();
            queryParams.append('destination', destination);
            queryParams.append('checkin', checkin);
            queryParams.append('checkout', checkout);
            queryParams.append('guests', guests);

            // 4. الانتقال إلى صفحة rooms.html
            window.location.href = `rooms.html?${queryParams.toString()}`;
        });
    }
});
// Clear all filters
document.getElementById("clearFiltersBtn")?.addEventListener("click", () => {
    const checkboxes = document.querySelectorAll(".rooms-filters input[type='checkbox']");
    const radios = document.querySelectorAll(".rooms-filters input[type='radio']");

    checkboxes.forEach(cb => cb.checked = false);
    radios.forEach(r => r.checked = false);
});
function initializeFilters() {
    const container = document.querySelector('.rooms-list .container');
    if (!container) return;

    // عناصر الفلتر
    const bedCheckboxes = Array.from(document.querySelectorAll('input[data-filter="bed"]'));
    const typeCheckboxes = Array.from(document.querySelectorAll('input[data-filter="type"]'));
    const priceRadios = Array.from(document.querySelectorAll('input[name="price"]'));
    const sortRadios = Array.from(document.querySelectorAll('input[name="sort"]'));
    const clearBtn = document.getElementById('clearFiltersBtn');

    // 2) خزن كل الغرف مع الـ index الأصلي عشان "Newest First"
    const roomItemsData = Array.from(document.querySelectorAll('.room-item')).map((el, index) => ({
        el,
        index
    }));

    function applyFiltersAndSort() {
        const selectedBeds = bedCheckboxes.filter(c => c.checked).map(c => c.value);
        const selectedTypes = typeCheckboxes.filter(c => c.checked).map(c => c.value);

        const selectedPriceRadio = priceRadios.find(r => r.checked && r.value);
        let priceMin = null;
        let priceMax = null;

        if (selectedPriceRadio && selectedPriceRadio.value !== "") {
            const [minStr, maxStr] = selectedPriceRadio.value.split("-");
            priceMin = parseInt(minStr, 10);
            priceMax = parseInt(maxStr, 10);
        }

        const selectedSortRadio = sortRadios.find(r => r.checked && r.value);
        const sortValue = selectedSortRadio ? selectedSortRadio.value : "default";

        // فلترة الغرف
        const visibleRooms = [];

        roomItemsData.forEach(item => {
            const el = item.el;
            const bed = el.dataset.bed || "";
            const type = el.dataset.type || "";
            const price = parseInt(el.dataset.price || "0", 10);

            let matchBed = true;
            if (selectedBeds.length > 0) {
                matchBed = selectedBeds.includes(bed);
            }

            let matchType = true;
            if (selectedTypes.length > 0) {
                matchType = selectedTypes.includes(type);
            }

            let matchPrice = true;
            if (priceMin !== null && priceMax !== null) {
                matchPrice = price >= priceMin && price <= priceMax;
            }

            const isMatch = matchBed && matchType && matchPrice;

            if (isMatch) {
                visibleRooms.push({
                    el,
                    index: item.index,
                    price
                });
            }
        });

        // ترتيب حسب sort
        if (sortValue === "price-asc") {
            visibleRooms.sort((a, b) => a.price - b.price);       // من واطي لعالي
        } else if (sortValue === "price-desc") {
            visibleRooms.sort((a, b) => b.price - a.price);       // من عالي لواطي
        } else {
            visibleRooms.sort((a, b) => a.index - b.index);       // ترتيبهم الأصلي (Newest First عندك)
        }

        // اخفي الكل الأول
        roomItemsData.forEach(item => {
            item.el.style.display = 'none';
        });

        // بعدين أظهر اللي مطابق وأرتّبه في الـ DOM
        visibleRooms.forEach(room => {
            room.el.style.display = 'flex';
            container.appendChild(room.el); // نحركه لآخر الـ container بالترتيب الجديد
        });
    }

    // كل تغيير في الفلاتر أو الـ sort يشغّل الفنكشن
    [...bedCheckboxes, ...typeCheckboxes, ...priceRadios, ...sortRadios].forEach(input => {
        // Remove old listeners to avoid duplicates if re-initialized (though simple replacement is safer)
        // For simplicity, we assume this runs once per page load or after content update.
        // To be safe against duplicates, we could clone nodes, but let's just add new listeners.
        // Since we clear container, room items are new. But filter inputs are static.
        // We should be careful not to add multiple listeners to filter inputs.
        // A simple way is to use `onchange` property or check if listener attached.
        // Or just assume it's fine for now as fetchAndRenderRooms runs once.
        input.onchange = applyFiltersAndSort;
    });

    // زر Clear
    if (clearBtn) {
        clearBtn.onclick = function () {
            bedCheckboxes.forEach(c => c.checked = false);
            typeCheckboxes.forEach(c => c.checked = false);
            priceRadios.forEach(r => r.checked = false);
            sortRadios.forEach(r => r.checked = false);

            // رجّع كل الغرف في وضعها الأصلي
            roomItemsData
                .sort((a, b) => a.index - b.index)
                .forEach(item => {
                    item.el.style.display = 'flex';
                    container.appendChild(item.el);
                });
        };
    }

    // أول تحميل: خليه يطبق مرة عشان لو حابة تحطي default في المستقبل
    applyFiltersAndSort();
}
