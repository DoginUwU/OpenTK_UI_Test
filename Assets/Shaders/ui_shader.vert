#version 330 core

layout (location = 0) in vec2 position; // Vertex coordinates
layout (location = 1) in vec4 backgroundColor;

out vec4 BackgroundColor;

uniform mat4 view;
uniform mat4 projection;

void main()
{
	gl_Position = vec4(position, 0.0,  1.0) * view * projection; // Coordinates return
	BackgroundColor = backgroundColor;
}