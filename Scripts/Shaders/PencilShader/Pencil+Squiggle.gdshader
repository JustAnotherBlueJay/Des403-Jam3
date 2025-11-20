shader_type canvas_item;
render_mode world_vertex_coords;

group_uniforms Squiggle;
/**
 * Noise texture scale
 * By default, the noise texture's size in world coordinates is set by its resolution
*/
uniform vec2 scale = vec2(1.0);
uniform float strength = 1.0;
/**
 * Number of squiggle frames per second
*/
uniform float fps = 6.0;
uniform sampler2D noise : filter_linear, repeat_enable;
group_uniforms;

varying vec4 modulate;
varying vec2 noise_uv;

#include "res://Scripts/Shaders/PencilShader/PencilShaderInclude.gdshaderinc"

void vertex() {
	modulate = COLOR;

	// Use world coordinates for scale-independent squiggles, offset by position to keep pattern attached to object
	noise_uv = (VERTEX - MODEL_MATRIX[3].xy) / (vec2(textureSize(noise, 0)) * scale);
}

// Use irrational constants for unique squiggles every frame
#define offset_multiplier vec2(PI, E)

void fragment() {
	
	float frame = floor(TIME * fps);
	
	vec2 noise_offset = vec2(floor(frame)) * offset_multiplier;
	float noise_sample = texture(noise, noise_uv + noise_offset).r * 4.0 * PI;
	vec2 direction = vec2(cos(noise_sample), sin(noise_sample));
	vec2 squiggle_uv = UV + direction * strength * 0.005;
	
	
	vec4 pencil = pencil_fragment(TEXTURE, squiggle_uv, frame);
	vec4 squiggle = texture(TEXTURE, squiggle_uv) * modulate;
	
	COLOR = pencil;
	//COLOR.r = min(squiggle.r, pencil.r);
	//COLOR.g = min(squiggle.g, pencil.g);
	//COLOR.b = min(squiggle.b, pencil.b);
	
	
	//COLOR = pencil_fragment(TEXTURE, UV);
}