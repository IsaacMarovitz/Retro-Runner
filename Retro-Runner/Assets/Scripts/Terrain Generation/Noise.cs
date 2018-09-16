﻿using System.Collections;
using UnityEngine;

public static class Noise {

    public enum NormalizeMode { Local, Global };

    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, NoiseSettings settings, Vector2 sampleCenter)
    {

        float[,] noiseMap = new float[mapWidth, mapHeight];

        System.Random prng = new System.Random(settings.seed);
        Vector2[] octaveOffsets = new Vector2[settings.octaves];

        float maxPossibleHight = 0;
        float amplitude = 1;
        float frequency = 1;

        for (int i = 0; i < settings.octaves; i++)
        {

            float offsetX = prng.Next(-100000, 100000) + settings.offset.x + sampleCenter.x;
            float offsetY = prng.Next(-100000, 100000) - settings.offset.y - sampleCenter.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);

            maxPossibleHight += amplitude;
            amplitude *= settings.persistance;

        }

        float maxLocalNoiseHeight = float.MinValue;
        float minLocalNoiseHeight = float.MaxValue;

        float halfwidth = mapWidth / 2f;
        float halfheight = mapHeight / 2f;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {

                amplitude = 1;
                frequency = 1;
                float noiseHight = 0;

                for (int i = 0; i < settings.octaves; i++)
                {

                    float sampleX = (x - halfwidth + octaveOffsets[i].x) / settings.scale * frequency;
                    float sampleY = (y - halfheight + octaveOffsets[i].y) / settings.scale * frequency;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHight += perlinValue * amplitude;

                    amplitude *= settings.persistance;
                    frequency *= settings.lacunarity;
                }

                if (noiseHight > maxLocalNoiseHeight)
                {

                    maxLocalNoiseHeight = noiseHight;

                }

                if (noiseHight < minLocalNoiseHeight)
                {

                    minLocalNoiseHeight = noiseHight;

                }
                noiseMap[x, y] = noiseHight;

                if (settings.normalizeMode == NormalizeMode.Global) {
                    float normalizedHight = (noiseMap[x, y] + 1) / maxPossibleHight;
                    noiseMap[x, y] = Mathf.Clamp(normalizedHight, 0, int.MaxValue);
                }
            }
        }

        if (settings.normalizeMode == NormalizeMode.Local) {

            for (int y = 0; y < mapHeight; y++) {
                for (int x = 0; x < mapWidth; x++) {
                    noiseMap[x, y] = Mathf.InverseLerp(minLocalNoiseHeight, maxLocalNoiseHeight, noiseMap[x, y]);
                } 
            }
        }
        return noiseMap;
    }

}

[System.Serializable]
public class NoiseSettings {
    public Noise.NormalizeMode normalizeMode;

    public float scale = 50;

    public int octaves = 8;
    [Range(0, 1)]
    public float persistance = 0.5f;
    public float lacunarity = 2f;
    [Range(0, 1000)]
    public int seed;
    public Vector2 offset;

    public void ValidateValues() {
        scale = Mathf.Max(scale, 0.01f);
        octaves = Mathf.Max(octaves, 1);
        persistance = Mathf.Clamp01(persistance);
        lacunarity = Mathf.Max(lacunarity, 1f);
    }
}
