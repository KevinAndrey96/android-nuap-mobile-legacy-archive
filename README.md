# Nuap: app Xamarin.Forms con módulo de comercios y pagos (archivo histórico)

![Estado: archivo histórico](https://img.shields.io/badge/Estado-archivo%20hist%C3%B3rico-lightgrey) ![Xamarin.Forms 4.8](https://img.shields.io/badge/Xamarin.Forms%204.8-3498DB) ![C#](https://img.shields.io/badge/C%23-239120) ![Android | iOS](https://img.shields.io/badge/Android%20%7C%20iOS-lightgrey)

> [!NOTE]
> Versión posterior de la app móvil de Nuap (2021), centrada en los comercios aliados: suma solicitudes de pago, historial de pagos y comprobantes a la app de clientes. El producto continúa en **[android-nuap-delivery-platform](https://github.com/KevinAndrey96/android-nuap-delivery-platform)**, que reúne todos sus componentes con documentación actualizada.
> 
> La rama `main` incluye el trabajo de `develop`; la rama `iOS` conserva los ajustes de la última versión publicada en iOS.

## Qué contiene

- Todo el flujo de cliente: catálogo por tienda y categoría, carrito, direcciones, pedidos, calificaciones y soporte.
- Módulo de comercio con inventario, productos destacados, ventas y cambio de estado de pedidos.
- Solicitudes de pago del comercio, historial de pagos, detalle, confirmación y comprobantes (`PaymentRequestPage`, `PaymentsPage`, `VoucherPage`).
- Códigos de error por servicio en las alertas para diagnosticar fallas de la API.
- Arquitectura MVVM con `ViewModels` y servicios por pantalla.

## Stack original

| Componente | Tecnología |
| :--- | :--- |
| Lenguaje | C# (.NET Standard 2.0) |
| UI | Xamarin.Forms 4.8 (XAML) |
| Plataformas | Xamarin.Android y Xamarin.iOS |
| Patrón | MVVM |

## Ejecutarlo localmente

Abre `nuap.sln` en Visual Studio 2019 o 2022 con la carga de trabajo de Xamarin y restaura los paquetes NuGet. Xamarin dejó de tener soporte en mayo de 2024; la versión vigente del producto vive en el monorepo.

## Estado del repositorio

- Se conserva sin cambios funcionales como referencia del código original (2021).
- No recibe actualizaciones de dependencias; el mantenimiento ocurre en [android-nuap-delivery-platform](https://github.com/KevinAndrey96/android-nuap-delivery-platform).
- En noviembre de 2026 se depuró el historial completo: se retiraron un APK de 89 MB y la llave de Google Maps. Todos los commits conservan su fecha original.

## Autoría

Kevin Andrey Herrera Silva ([@KevinAndrey96](https://github.com/KevinAndrey96)), con aportes de Viviana Arango y Miguel Ochoa.

## Licencia

Código desarrollado para un cliente y publicado como muestra de portafolio. No incluye licencia de código abierto: todos los derechos reservados.
