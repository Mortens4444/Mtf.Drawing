# Mtf.Drawing

**Mtf.Drawing** is a modern, C#-based 2D geometry and rendering library designed to simplify the mathematical manipulation and GDI+ rendering of shapes. 

The project strictly separates the geometric definition of shapes (data and logic) from their physical display (rendering), ensuring the code remains clean, testable, and highly maintainable.

## 📦 Key Features

* **Geometric Shapes (Math/Geometry):** `CircleF`, `LineF`, `RectF`, `OrientedRectF`, `PolylineF`, `TextLayout`.
* **Spatial Transformations:** Support for moving (`Move`), scaling (`Resize`), and rotating (`Rotate`) via the `IShape` interface.
* **Collision Detection:** Built-in `Contains` and `Intersects` methods for shapes.
* **GDI+ Rendering:** Dedicated `Primitive` classes (`CirclePrimitive`, `RectanglePrimitive`, `LinePrimitive`, etc.) handle drawing graphics onto a `Graphics` canvas.
* **Screen Sampling:** A specialized `InverseRectanglePrimitive` for color inversion utilizing the Win32 API.

## 🏗️ Architecture

The library is structured into three main namespaces:

### 1. `Mtf.Drawing.Interfaces`
Contains the foundational interfaces that provide the building blocks of the system:
* `IShape`: The core definition of geometric shapes (requiring a center point, move, rotate, resize, and containment checks).
* `IPrimitive`: The base for all renderable objects, enforcing the implementation of `DrawOnGraphics(Graphics g, Color color)`.

### 2. `Mtf.Drawing.Geometry`
A collection of immutable (or functionally modifiable) `readonly record struct` and `class` types. These classes contain *no* drawing logic, only pure mathematics.
* They utilize the `GeometryMath` static helper class for complex calculations (e.g., rotating points).

### 3. `Mtf.Drawing.Render`
These classes (e.g., `CirclePrimitive`, `TextPrimitive`) bridge the gap between in-memory geometry and visual output, binding the data to the `System.Drawing.Graphics` object.

## 🚀 Usage Example

### Creating and Transforming Geometry

```csharp
using Mtf.Drawing.Geometry;
using System.Drawing;

// Create a circle
var circle = new CircleF(new PointF(10, 10), 5);

// Move and scale the shape
var movedCircle = circle.Move(15, 20);
var scaledCircle = movedCircle.Resize(2.0f);

// Collision detection
bool isHit = scaledCircle.Contains(new PointF(25, 30));