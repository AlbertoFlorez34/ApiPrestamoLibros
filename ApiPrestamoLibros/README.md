Ejemplo de uso rápido
➕ Crear un libro

POST /api/libros

{
  "titulo": "Don Quijote de la Mancha",
  "autor": "Miguel de Cervantes",
  "cantidad": 4
}

🔍 Obtener libro por ID

GET /api/libros/1

✏️ Actualizar libro

PUT /api/libros/1

{
  "titulo": "Don Quijote - Edición revisada",
  "autor": "Miguel de Cervantes",
  "cantidad": 10
}

❌ Eliminar libro

DELETE /api/libros/1

📋 Listar todos

GET /api/libros