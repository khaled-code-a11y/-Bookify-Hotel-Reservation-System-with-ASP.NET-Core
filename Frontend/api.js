const API_BASE_URL = 'https://depihotel.runasp.net/api';

const api = {
    async getAllRooms() {
        try {
            const response = await fetch(`${API_BASE_URL}/Room/getAllRooms`);
            if (!response.ok) throw new Error('Failed to fetch rooms');
            const rawRooms = await response.json();

            return rawRooms.map(room => this._normalizeRoom(room));
        } catch (error) {
            console.error('Error fetching rooms:', error);
            return [];
        }
    },

    async getRoomById(id) {
        try {
            const response = await fetch(`${API_BASE_URL}/Room/getRoomById/${id}`);
            if (!response.ok) throw new Error('Failed to fetch room');
            const rawRoom = await response.json();
            return this._normalizeRoom(rawRoom);
        } catch (error) {
            console.error(`Error fetching room ${id}:`, error);
            return null;
        }
    },

    async reserveRoom(reservationData) {
        try {
            const response = await fetch(`${API_BASE_URL}/Room/reserveRoom`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(reservationData)
            });

            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(errorText || `HTTP error! status: ${response.status}`);
            }
            return true;
        } catch (error) {
            console.error('Error reserving room:', error);
            throw error;
        }
    },

    _normalizeRoom(room) {
        // Helper to map API structure to Frontend structure
        // API returns: { roomId, roomNumber, typeId, isAvailable, ... }
        // Frontend needs: { id, price, roomPhotoUrl, description, capacity, roomType, ... }

        const types = { 1: "Standard", 2: "Suite", 3: "Deluxe" };
        const prices = { 1: 150, 2: 300, 3: 500 };
        const capacities = { 1: 2, 2: 4, 3: 3 };

        // Random images for demo purposes since API is missing them
        const images = [
            "img/vojtech-bruzek-Yrxr3bsPdS0-unsplash 1.png",
            "img/visualsofdana-T5pL6ciEn-I-unsplash 1.png",
            "img/chastity-cortijo-M8iGdeTSOkg-unsplash 1.png",
            "img/reisetopia-pSDe7ePo0Tc-unsplash 1.png"
        ];
        // Use roomId to deterministically select an image
        const randomImage = images[(room.roomId || 0) % images.length];

        return {
            id: room.roomId,
            roomNumber: room.roomNumber,
            roomType: room.roomType || types[room.typeId] || "Standard",
            price: room.price || prices[room.typeId] || 200,
            roomPhotoUrl: room.roomPhotoUrl || randomImage,
            description: room.description || "Experience luxury and comfort in our carefully designed rooms.",
            capacity: room.capacity || capacities[room.typeId] || 2,
            isAvailable: room.isAvailable
        };
    }
};
