using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pazzle : MonoBehaviour
{

     // タイルの種類
    public enum TileType
    {
        NONE, // 何も無い
        GROUBD, // 地面
        CANDY, // キャンディー
        BLOCK, // ブロック
        SPONE, // スポーンブロック

        SCORE, // 点数
    }

    public Sprite groundSprite;  // 地面のスプライト
    public Sprite blockSprite;   // ブロックのスプライト

    private int rows = 7;        // 行数
    private int columns = 7;     // 列数
    public TileType[,] tileList; // タイル情報を管理する二次元配列
    public float tileSize;       // タイルのサイズ

    // ステージを作成
    private void CreateStage()
    {

        int[,] tileList = new int [rows,columns];

        // ステージの中心位置を計算
        middleOffset.x = columns * tileSize * 0.5f - tileSize * 0.5f;
        middleOffset.y = rows * tileSize * 0.5f - tileSize * 0.5f;

        for ( int y = 0; y < rows; y++ )
        {
            for ( int x = 0; x < columns; x++ )
            {
                var val = tileList[ x, y ];
                // 何も無い場所は無視
                if ( val == TileType.NONE ) continue;
                // タイルの名前に行番号と列番号を付与
                var name = "tile" + y + "_" + x;
                // タイルのゲームオブジェクトを作成
                var tile = new GameObject( name ); 
                // タイルにスプライトを描画する機能を追加
                var sr = tile.AddComponent<SpriteRenderer>();
                // タイルのスプライトを設定
                sr.sprite = groundSprite;
                // タイルの位置を設定
                tile.transform.position = GetDisplayPosition( x, y );
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateStage(); // ステージを作成
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
