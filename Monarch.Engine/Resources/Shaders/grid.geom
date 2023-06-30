#version 440

layout(points) in;
layout(triangle_fan, max_vertices = 7) out;

uniform float radius;
uniform float halfRadius;
uniform float apothem;

layout(location = 0) in vec3 gPosition;
layout(location = 1) in vec4 gInnerColor;
layout(location = 2) in vec4 gBorderColor;
layout(location = 3) in vec4 gClipPosition;

void main()
{
	vec3 position = gl_in[0].gl_Position.xyz;

	// Perform initial calculations
	float topY = position.y + apothem;
	float bottomY = position.y - apothem;
	float leftX = position.x - radius;
	float halfLeftX = position.x - halfRadius;
	float halfRightX = position.x + halfRadius;
	float rightX = position.x + radius;

	// Emit initial center point
	gl_Position = vec4(position, 1.0);
	EmitVertex();

	// Emit top-right point
	gl_Position = vec4(halfRightX, topY, position.z, 1.0);
	EmitVertex();

	// Emit right point
	gl_Position = vec4(rightX, position.y, position.z, 1.0);
	EmitVertex();

	// Emit bottom-right point
	gl_Position = vec4(halfRightX, bottomY, position.z, 1.0);
	EmitVertex();

	// Emit bottom-left point
	gl_Position = vec4(halfLeftX, bottomY, position.z, 1.0);
	EmitVertex();

	// Emit left point
	gl_Position = vec4(leftX, position.y, position.z, 1.0);
	EmitVertex();

	// Emit top-left point
	gl_Position = vec4(halfLeftX, topY, position.z, 1.0);
	EmitVertex();

	EndPrimitive();
}