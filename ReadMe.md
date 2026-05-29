# Mtf.Drawing

A lightweight 2D drawing abstraction layer built on top of `System.Drawing.Common`, providing simple geometric primitives and a unified rendering interface.

## Overview

`Mtf.Drawing` provides basic drawing primitives that can be rendered onto a `Graphics` surface:

- Point (pixel-level drawing)
- Line (vector line rendering)
- Rectangle (filled or outlined)
- InverseRectangle (custom inverse rendering logic)
- Circle
- Text rendering via `String`

All elements implement a common `IDrawingElement` interface, enabling uniform rendering.

---

## Features

- Simple object-based drawing model
- Unified `DrawOnGraphics(Graphics)` API
- Optional color overrides
- Basic geometry utilities (e.g. distance calculation)
- Minimal abstraction over `System.Drawing`