#version 440

layout(points) in;
layout(triangle_strip, max_vertices = 12) out;

uniform float radius;
uniform float apothem;

layout(location = 0) in vec3 gPosition[];
layout(location = 1) in float gBorderThickness[];
layout(location = 2) in vec4 gInnerColor[];
layout(location = 3) in vec4 gBorderColor[];

layout(location = 0) out vec4 fColor;

void emitHexagon(vec3 position, float radius, float apothem, vec4 color)
{
	fColor = color;

	// Perform initial calculations
	float halfRadius = radius * 0.5;
	float topY = position.y + apothem;
	float bottomY = position.y - apothem;
	float leftX = position.x - radius;
	float halfLeftX = position.x - halfRadius;
	float halfRightX = position.x + halfRadius;
	float rightX = position.x + radius;

	// Emit left point
	gl_Position = vec4(leftX, position.y, position.z, 1.0);
	EmitVertex();

	// Emit top-left point
	gl_Position = vec4(halfLeftX, topY, position.z, 1.0);
	EmitVertex();

	// Emit bottom-left point
	gl_Position = vec4(halfLeftX, bottomY, position.z, 1.0);
	EmitVertex();

	// Emit top-right point
	gl_Position = vec4(halfRightX, topY, position.z, 1.0);
	EmitVertex();

	// Emit bottom-right point
	gl_Position = vec4(halfRightX, bottomY, position.z, 1.0);
	EmitVertex();

	// Emit right point
	gl_Position = vec4(rightX, position.y, position.z, 1.0);
	EmitVertex();

	EndPrimitive();
}

void main()
{
	vec3 position = gl_in[0].gl_Position.xyz;

	emitHexagon(position, radius, apothem, gBorderColor[0]);
	emitHexagon(position, radius - gBorderThickness[0], apothem - gBorderThickness[0], gInnerColor[0]);
}